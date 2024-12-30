using Antlr4.Runtime;
using ModPosh.Hcl.Utilities;
using ModPosh.Hcl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using System.Text.RegularExpressions;

namespace ModPosh.Hcl
{
    /// <summary>
    /// A client class for validating and parsing HCL input, providing both syntax validation
    /// and structural parsing of HCL documents into a structured format.
    /// </summary>
    public class Client
    {
        private readonly bool enforceHclV2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="enforceHclV2">
        /// Specifies whether to enforce HCL v2 compliance during validation.
        /// </param>
        public Client(bool enforceHclV2 = false)
        {
            this.enforceHclV2 = enforceHclV2;
        }

        /// <summary>
        /// Validates the provided HCL input for syntax errors.
        /// Optionally enforces HCL v2 compliance based on client configuration.
        /// </summary>
        /// <param name="hclInput">The HCL input string to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> containing the validation result and errors.</returns>
        public ValidationResult Validate(string hclInput)
        {
            var preprocessedInput = PreprocessMultilineStrings(hclInput);

            var lexer = new HclLexer(new AntlrInputStream(preprocessedInput));
            var tokens = new CommonTokenStream(lexer);
            var parser = new HclParser(tokens);

            var errorListener = new SyntaxErrorListener();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            parser.document();

            return new ValidationResult
            {
                IsValid = !errorListener.HasErrors,
                Errors = errorListener.GetErrorsList(),
                DetailedError = GenerateDetailedError(preprocessedInput, errorListener.GetErrorsList())
            };
        }
        /// <summary>
        /// Generates a detailed error message based on common syntax issues.
        /// </summary>
        /// <param name="hclInput">The original HCL input string.</param>
        /// <param name="errors">A list of syntax errors detected during validation.</param>
        /// <returns>A detailed error message with suggestions for fixing specific issues.</returns>
        /// 
        private string GenerateDetailedError(string hclInput, List<string> errors)
        {
            foreach (var error in errors)
            {
                if (error.Contains("expecting {'${', BOOL, STRING, NUMBER, IDENTIFIER, '{', '['}") &&
                    error.Contains("Offending token: ]"))
                {
                    // Extract offending line number
                    var lineNumber = ExtractLineNumberFromError(error);
                    if (lineNumber != null)
                    {
                        var offendingLine = GetLineByNumber(hclInput, lineNumber.Value - 1); // Check the previous line
                        if (!string.IsNullOrWhiteSpace(offendingLine) && offendingLine.TrimEnd().EndsWith(","))
                        {
                            return $"{error} - A potential trailing comma is detected on line {lineNumber.Value - 1}. Ensure no trailing commas exist in lists or maps.";
                        }
                    }
                }
            }
            return string.Join("; ", errors);
        }

        /// <summary>
        /// Extracts the line number from a given error message string.
        /// </summary>
        /// <param name="error">The error message containing the line number.</param>
        /// <returns>The line number as an integer, or null if the line number cannot be determined.</returns>
        private int? ExtractLineNumberFromError(string error)
        {
            var match = Regex.Match(error, @"Line (\d+):");
            if (match.Success && int.TryParse(match.Groups[1].Value, out var lineNumber))
            {
                return lineNumber;
            }
            return null;
        }

        /// <summary>
        /// Retrieves the content of a specific line in the provided HCL input string.
        /// </summary>
        /// <param name="text">The full HCL input string, with lines separated by newlines.</param>
        /// <param name="lineNumber">The 1-based line number to retrieve.</param>
        /// <returns>The content of the specified line, or null if the line number is out of range.</returns>
        private string? GetLineByNumber(string text, int lineNumber)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            if (lineNumber > 0 && lineNumber <= lines.Length)
            {
                return lines[lineNumber - 1];
            }
            return null;
        }

        /// <summary>
        /// Parses the provided HCL input and returns a structured representation of the document.
        /// </summary>
        /// <param name="hclInput">The raw HCL input string to parse.</param>
        /// <returns>
        /// A structured object representing the parsed HCL document, including blocks, attributes, and values.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws an exception if syntax errors are detected during parsing.
        /// </exception>
        public object Parse(string hclInput)
        {
            var preprocessedInput = PreprocessMultilineStrings(hclInput);

            var lexer = new HclLexer(new AntlrInputStream(preprocessedInput));
            var tokens = new CommonTokenStream(lexer);
            var parser = new HclParser(tokens);

            var errorListener = new SyntaxErrorListener();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            var document = parser.document();

            if (errorListener.HasErrors)
            {
                throw new Exception("Syntax errors detected:\n" + string.Join("\n", errorListener.GetErrorsList()));
            }

            return VisitDocument(document);
        }

        /// <summary>
        /// Processes the top-level document context to extract and process all blocks.
        /// </summary>
        /// <param name="context">The document context from the HCL parser.</param>
        /// <returns>An <see cref="HclDocument"/> representing the parsed document structure.</returns>
        private HclDocument VisitDocument(HclParser.DocumentContext context)
        {
            var document = new HclDocument();

            foreach (var blockContext in context.block())
            {
                var block = VisitBlock(blockContext);

                switch (block.Type)
                {
                    case "provider":
                        document.Providers.Add((Provider)block);
                        break;
                    case "resource":
                        document.Resources.Add((Resource)block);
                        break;
                    case "variable":
                        document.Variables.Add((Variable)block);
                        break;
                    case "module":
                        document.Modules.Add((Module)block);
                        break;
                    case "data":
                        document.DataBlocks.Add((Data)block);
                        break;
                    case "terraform":
                        document.TerraformBlocks.Add((Terraform)block);
                        break;
                    case "output":
                        document.Outputs.Add((Output)block);
                        break;
                    default:
                        Console.WriteLine($"Unhandled block type: {block.Type}");
                        break;
                }
            }

            return document;
        }

        /// <summary>
        /// Visits a block and extracts its type, name, optional label, and body.
        /// </summary>
        /// <param name="context">The block context from the HCL parser.</param>
        /// <returns>An <see cref="HclBlock"/> representing the parsed block.</returns>
        private HclBlock VisitBlock(HclParser.BlockContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Block context is null");

            var blockType = context.IDENTIFIER()?.GetText() ?? throw new Exception("Block type is null");
            var blockLabels = context.blockLabel()?.children
                ?.Select(label => label.GetText().Trim('"'))
                .ToList() ?? new List<string>();

            var blockName = blockLabels.FirstOrDefault();
            var blockBody = context.body() != null ? VisitBody(context.body()) : new Dictionary<string, HclValue>();

            return blockType switch
            {
                "provider" => new Provider { Type = blockType, Name = blockName, Body = blockBody },
                "resource" => new Resource { Type = blockType, Name = blockName, Body = blockBody },
                "variable" => new Variable { Type = blockType, Name = blockName, Body = blockBody },
                "module" => new Module { Type = blockType, Name = blockName, Body = blockBody },
                "data" => new Data { Type = blockType, Name = blockName, Body = blockBody },
                "terraform" => VisitTerraformBlock(blockBody),
                "output" => VisitOutputBlock(blockName, blockBody),
                _ => throw new Exception($"Unhandled block type: {blockType}")
            };
        }

        /// <summary>
        /// Processes the body of a block and extracts attributes, nested blocks, and handles comments/newlines.
        /// </summary>
        /// <param name="context">The body context from the HCL parser.</param>
        /// <returns>A dictionary representing the body's parsed structure.</returns>
        private Dictionary<string, HclValue> VisitBody(HclParser.BodyContext context)
        {
            if (context == null)
                return new Dictionary<string, HclValue>();

            var bodyData = new Dictionary<string, HclValue>();

            foreach (var element in context.children ?? Enumerable.Empty<IParseTree>())
            {
                switch (element)
                {
                    case HclParser.AttributeContext attr:
                        bodyData[attr.IDENTIFIER().GetText()] = VisitValue(attr.value());
                        break;

                    case HclParser.NestedBlockContext nested:
                        var nestedBlock = VisitNestedBlock(nested);
                        var nestedType = nestedBlock["type"]?.Value?.ToString();

                        if (string.IsNullOrWhiteSpace(nestedType))
                        {
                            Console.WriteLine($"Encountered nested block with null or empty type: {nestedBlock}");
                            continue;
                        }

                        if (!bodyData.ContainsKey(nestedType))
                        {
                            bodyData[nestedType] = new HclValue
                            {
                                Type = HclValueType.List,
                                Value = new List<Dictionary<string, HclValue>>()
                            };
                        }

                        ((List<Dictionary<string, HclValue>>)bodyData[nestedType].Value!).Add(nestedBlock);
                        break;

                    default:
                        Console.WriteLine($"Unhandled element in body: {element.GetText()}");
                        break;
                }
            }

            return bodyData;
        }

        /// <summary>
        /// Visits a nested block and extracts its type, name, and body.
        /// </summary>
        /// <param name="context">The nested block context from the HCL parser.</param>
        /// <returns>A dictionary representing the nested block structure.</returns>
        private Dictionary<string, HclValue> VisitNestedBlock(HclParser.NestedBlockContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), "Nested block context is null");

            var nestedType = context.IDENTIFIER()?.GetText() ?? throw new Exception("Nested block type is null");
            var nestedLabels = context.blockLabel()?.children
                ?.Select(label => label.GetText().Trim('"'))
                .ToList() ?? new List<string>();

            var nestedName = nestedLabels.FirstOrDefault();
            var nestedBody = context.body() != null ? VisitBody(context.body()) : new Dictionary<string, HclValue>();

            return new Dictionary<string, HclValue>
            {
                ["type"] = new HclValue { Type = HclValueType.String, Value = nestedType },
                ["name"] = new HclValue { Type = HclValueType.String, Value = nestedName },
                ["body"] = new HclValue { Type = HclValueType.Map, Value = nestedBody }
            };
        }

        /// <summary>
        /// Visits a Terraform block and extracts its backends.
        /// </summary>
        /// <param name="body">The body of the Terraform block.</param>
        /// <returns>A <see cref="Terraform"/> object representing the block.</returns>
        private Terraform VisitTerraformBlock(Dictionary<string, HclValue> body)
        {
            var terraform = new Terraform { Type = "terraform" };

            if (body.TryGetValue("backend", out var backendValue) &&
                backendValue.Value is List<Dictionary<string, HclValue>> backendBlocks)
            {
                foreach (var backendBlock in backendBlocks)
                {
                    var backendType = backendBlock.ContainsKey("type") ? backendBlock["type"].Value?.ToString() : null;
                    var backendBody = backendBlock.ContainsKey("body") ? backendBlock["body"].Value as Dictionary<string, HclValue> : null;

                    if (backendType != null)
                    {
                        terraform.Backends.Add(new Backend
                        {
                            Type = backendType,
                            Body = backendBody
                        });
                    }
                    else
                    {
                        Console.WriteLine("Backend block missing required 'type' field.");
                    }
                }
            }

            return terraform;
        }

        /// <summary>
        /// Visits an output block and extracts its name and value.
        /// </summary>
        /// <param name="name">The name of the output block.</param>
        /// <param name="body">The body of the output block.</param>
        /// <returns>An <see cref="Output"/> object representing the block.</returns>
        private Output VisitOutputBlock(string? name, Dictionary<string, HclValue> body)
        {
            var output = new Output { Type = "output", Name = name };

            if (body.TryGetValue("value", out var value))
            {
                output.Value = value;
            }
            else
            {
                throw new Exception($"Output block '{name}' is missing a 'value' attribute.");
            }

            return output;
        }

        /// <summary>
        /// Preprocesses the HCL input to handle multi-line strings with `<<-EOT ... EOT` syntax.
        /// </summary>
        /// <param name="input">The raw HCL input string.</param>
        /// <returns>The preprocessed HCL string with multi-line strings collapsed into single-line strings.</returns>
        private string PreprocessMultilineStrings(string input)
        {
            var pattern = @"<<-\s*(\w+)\s*\n(.*?)\n\s*\1";
            return Regex.Replace(input, pattern, match =>
            {
                var identifier = match.Groups[1].Value;
                var content = match.Groups[2].Value;

                var collapsedContent = content
                    .Trim()
                    .Replace("\n", "\\n")
                    .Replace("\"", "\\\"");

                return $"\"{collapsedContent}\"";
            }, RegexOptions.Singleline);
        }

        /// <summary>
        /// Visits a value context and determines its type.
        /// </summary>
        /// <param name="context">The value context from the HCL parser.</param>
        /// <returns>An <see cref="HclValue"/> representing the parsed value.</returns>
        private HclValue VisitValue(HclParser.ValueContext context)
        {
            if (context.STRING() != null)
            {
                return new HclValue
                {
                    Type = HclValueType.String,
                    Value = context.STRING().GetText().Trim('"')
                };
            }
            if (context.NUMBER() != null)
            {
                return new HclValue
                {
                    Type = HclValueType.Number,
                    Value = double.Parse(context.NUMBER().GetText())
                };
            }
            if (context.BOOL() != null)
            {
                return new HclValue
                {
                    Type = HclValueType.Boolean,
                    Value = context.BOOL().GetText() == "true"
                };
            }
            if (context.list() != null)
            {
                return new HclValue
                {
                    Type = HclValueType.List,
                    Value = VisitList(context.list())
                };
            }
            if (context.map() != null)
            {
                return new HclValue
                {
                    Type = HclValueType.Map,
                    Value = VisitMap(context.map())
                };
            }

            return new HclValue
            {
                Type = HclValueType.Unknown,
                Value = null
            };
        }

        /// <summary>
        /// Processes a list and extracts its elements.
        /// </summary>
        /// <param name="context">The list context from the HCL parser.</param>
        /// <returns>A list of <see cref="HclValue"/> objects representing the elements.</returns>
        private List<HclValue> VisitList(HclParser.ListContext context)
        {
            return context.value().Select(VisitValue).ToList();
        }

        /// <summary>
        /// Processes a map and extracts its key-value pairs.
        /// </summary>
        /// <param name="context">The map context from the HCL parser.</param>
        /// <returns>A dictionary representing the map.</returns>
        private Dictionary<string, object?> VisitMap(HclParser.MapContext context)
        {
            if (context?.mapEntry() == null)
            {
                throw new Exception("Map context or entries are null.");
            }

            var map = new Dictionary<string, object?>();

            foreach (var entry in context.mapEntry())
            {
                var key = entry.mapKey().STRING()?.GetText()?.Trim('"') ??
                          entry.mapKey().IDENTIFIER()?.GetText();

                if (key != null)
                {
                    map[key] = VisitValue(entry.value());
                }
                else
                {
                    throw new Exception($"Invalid key in map: {entry.GetText()}");
                }
            }

            return map;
        }
    }
}
