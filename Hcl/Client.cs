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
        /// <returns>A ValidationResult object containing the validation result and errors.</returns>
        public ValidationResult Validate(string hclInput)
        {
            var lexer = new HclLexer(new AntlrInputStream(hclInput));
            var parser = new HclParser(new CommonTokenStream(lexer));

            var errorListener = new SyntaxErrorListener();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            parser.document(); // Parse the document

            var validationResult = new ValidationResult
            {
                IsValid = !errorListener.HasErrors,
                Errors = errorListener.GetErrorsList(),
                DetailedError = GenerateDetailedError(hclInput, errorListener.GetErrorsList())
            };

            if (validationResult.IsValid && enforceHclV2)
            {
                validationResult = EnforceHclV2Compliance(hclInput);
            }

            return validationResult;
        }

        /// <summary>
        /// Generates a detailed error message based on common syntax issues.
        /// </summary>
        /// <param name="hclInput">The HCL input string.</param>
        /// <param name="errors">The list of syntax errors detected.</param>
        /// <returns>A detailed error message with suggestions for fixing issues.</returns>
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
        /// Extracts the line number from the error message.
        /// </summary>
        /// <param name="error">The error message string.</param>
        /// <returns>The line number as an integer, or null if not found.</returns>
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
        /// Retrieves the content of a specific line in a string by line number.
        /// </summary>
        /// <param name="text">The input string with lines separated by newlines.</param>
        /// <param name="lineNumber">The 1-based line number to retrieve.</param>
        /// <returns>The content of the specified line, or null if out of range.</returns>
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
        /// Retrieves the offending line from the input based on the error message.
        /// </summary>
        /// <param name="hclInput">The HCL input string.</param>
        /// <param name="error">The error message containing the line number.</param>
        /// <returns>The offending line of HCL code, or null if not found.</returns>
        private string? GetOffendingLine(string hclInput, string error)
        {
            var match = System.Text.RegularExpressions.Regex.Match(error, @"Line (\d+):");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int lineNumber))
            {
                var lines = hclInput.Split(new[] { '\r', '\n' }, StringSplitOptions.None);
                if (lineNumber > 0 && lineNumber <= lines.Length)
                {
                    return lines[lineNumber - 1];
                }
            }
            return null;
        }

        /// <summary>
        /// Enforces additional compliance rules specific to HCL v2.
        /// </summary>
        /// <param name="hclInput">The raw HCL input string.</param>
        /// <returns>
        /// A <see cref="ValidationResult"/> indicating whether the input complies with HCL v2 rules.
        /// </returns>
        private ValidationResult EnforceHclV2Compliance(string hclInput)
        {
            var errors = new List<string>();

            // Example compliance rule: Ensure all map keys are strings.
            if (hclInput.Contains("{") && hclInput.Contains("=") && !hclInput.Contains("\""))
            {
                errors.Add("HCL v2 requires all map keys to be enclosed in double quotes.");
            }

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
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
            var lexer = new HclLexer(new AntlrInputStream(hclInput));
            var parser = new HclParser(new CommonTokenStream(lexer));

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
        /// <returns>A list of parsed block objects.</returns>
        private List<object> VisitDocument(HclParser.DocumentContext context)
        {
            var blocks = new List<object>();
            foreach (var block in context.block())
            {
                try
                {
                    blocks.Add(VisitBlock(block));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error visiting block: {block.GetText()}\n{ex.Message}");
                    throw;
                }
            }
            return blocks;
        }

        /// <summary>
        /// Visits a block and extracts its type, name, optional label, and body.
        /// </summary>
        /// <param name="context">The block context from the HCL parser.</param>
        /// <returns>A dictionary representing the block's parsed structure.</returns>
        private Dictionary<string, object?> VisitBlock(HclParser.BlockContext context)
        {
            var blockType = context.IDENTIFIER().GetText();

            // Collect block labels from the blockLabel rule
            var blockLabels = context.blockLabel()?.children
                .Select(label => label.GetText().Trim('"')) // Trim quotes if STRING
                .ToList();

            // Determine the primary name and optional label
            var blockName = blockLabels != null && blockLabels.Count > 0 ? blockLabels[0] : null;
            var optionalLabel = blockLabels != null && blockLabels.Count > 1 ? blockLabels[1] : null;

            // Check if the block has a body
            var body = context.body() != null ? VisitBody(context.body()) : new Dictionary<string, object?>();

            return new Dictionary<string, object?>
            {
                ["type"] = blockType,
                ["name"] = blockName,
                ["optionalLabel"] = optionalLabel,
                ["body"] = body
            };
        }

        /// <summary>
        /// Visits the body of a block and extracts attributes, nested blocks, and handles comments/newlines.
        /// </summary>
        /// <param name="context">The body context from the HCL parser.</param>
        /// <returns>A dictionary representing the body's parsed structure.</returns>
        private Dictionary<string, object?> VisitBody(HclParser.BodyContext context)
        {
            if (context == null || context.children == null || context.children.Count == 0)
            {
                // Return an empty dictionary for empty or null body contexts
                return new Dictionary<string, object?>();
            }

            var bodyData = new Dictionary<string, object?>();

            foreach (var element in context.children)
            {
                switch (element)
                {
                    case HclParser.AttributeContext attr:
                        bodyData[attr.IDENTIFIER().GetText()] = VisitValue(attr.value());
                        break;

                    case HclParser.NestedBlockContext nested:
                        bodyData[nested.IDENTIFIER().GetText()] = VisitBody(nested.body());
                        break;

                    default:
                        Console.WriteLine($"Unhandled element in body: {element.GetText()}");
                        break;
                }
            }

            return bodyData;
        }

        /// <summary>
        /// Visits a value context from the HCL parser and determines its type.
        /// </summary>
        /// <param name="context">The value context from the HCL parser.</param>
        /// <returns>
        /// An object representing the value, which could be a boolean, string, number, list, map,
        /// reference, interpolation, or function call.
        /// </returns>
        private object? VisitValue(HclParser.ValueContext context)
        {
            if (context.STRING() != null)
            {
                // Return the string value with quotes trimmed
                return context.STRING().GetText().Trim('"');
            }
            if (context.NUMBER() != null)
            {
                // Parse and return a numeric value
                return double.Parse(context.NUMBER().GetText());
            }
            if (context.BOOL() != null)
            {
                // Return the boolean value
                return context.BOOL().GetText() == "true";
            }
            if (context.list() != null)
            {
                // Process and return a list of values
                return VisitList(context.list());
            }
            if (context.map() != null)
            {
                // Process and return a map of key-value pairs
                return VisitMap(context.map());
            }
            if (context.reference() != null)
            {
                // Process and return a reference
                return VisitReference(context.reference());
            }
            if (context.interpolation() != null)
            {
                // Process and return an interpolation expression
                return VisitInterpolation(context.interpolation());
            }
            if (context.functionCall() != null)
            {
                // Process and return a function call
                return VisitFunctionCall(context.functionCall());
            }

            // If no known type is found, return null
            return null;
        }

        /// <summary>
        /// Processes a function call context and extracts its textual representation.
        /// </summary>
        /// <param name="context">The function call context from the HCL parser.</param>
        /// <returns>
        /// A string representing the function call, including the function name and arguments.
        /// </returns>
        private string VisitFunctionCall(HclParser.FunctionCallContext context)
        {
            var functionName = context.IDENTIFIER().GetText();
            var arguments = context.value().Select(VisitValue).ToList();

            return $"{functionName}({string.Join(", ", arguments)})";
        }

        /// <summary>
        /// Processes a list and extracts its elements.
        /// </summary>
        /// <param name="context">The list context from the HCL parser.</param>
        /// <returns>A list of parsed elements.</returns>
        private List<object?> VisitList(HclParser.ListContext context)
        {
            return context.value().Select(VisitValue).ToList();
        }

        /// <summary>
        /// Processes a reference and constructs its representation.
        /// </summary>
        /// <param name="context">The reference context from the HCL parser.</param>
        /// <returns>The textual representation of the reference.</returns>
        private string VisitReference(HclParser.ReferenceContext context)
        {
            var parts = new List<string> { context.IDENTIFIER(0).GetText() };

            for (int i = 1; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);

                if (child is ITerminalNode terminal)
                {
                    parts.Add(terminal.GetText());
                }
            }

            return string.Join(".", parts);
        }

        /// <summary>
        /// Processes a map context and extracts key-value pairs.
        /// </summary>
        /// <param name="context">The map context from the HCL parser.</param>
        /// <returns>
        /// A dictionary where the keys are strings and the values are parsed objects,
        /// representing the key-value pairs in the HCL map.
        /// </returns>
        /// <exception cref="Exception">Throws if the map context or map entries are null.</exception>
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
                    // Parse the value associated with the key
                    map[key] = VisitValue(entry.value());
                }
                else
                {
                    throw new Exception($"Invalid key in map: {entry.GetText()}");
                }
            }

            return map;
        }

        /// <summary>
        /// Processes an interpolation and extracts its expression.
        /// </summary>
        /// <param name="context">The interpolation context from the HCL parser.</param>
        /// <returns>The string representation of the interpolation.</returns>
        private string VisitInterpolation(HclParser.InterpolationContext context)
        {
            return context.GetText();
        }
    }
}
