using Antlr4.Runtime;
using ModPosh.Hcl.Utilities;
using ModPosh.Hcl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;

namespace ModPosh.Hcl
{
    /// <summary>
    /// Client class for validating and parsing HCL input.
    /// </summary>
    public class Client
    {
        private readonly bool enforceHclV2;

        /// <summary>
        /// Initializes the HCL client with an optional flag to enforce HCL v2 compliance.
        /// </summary>
        /// <param name="enforceHclV2">Whether to enforce HCL v2 compliance during validation.</param>
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
                Errors = errorListener.GetErrorsList()
            };

            if (validationResult.IsValid && enforceHclV2)
            {
                validationResult = EnforceHclV2Compliance(hclInput);
            }

            return validationResult;
        }

        /// <summary>
        /// Enforces HCL v2 compliance rules on the provided HCL input.
        /// </summary>
        /// <param name="hclInput">The HCL input string.</param>
        /// <returns>A ValidationResult with errors if HCL v2 compliance fails.</returns>
        private ValidationResult EnforceHclV2Compliance(string hclInput)
        {
            var errors = new List<string>();

            // Example enforcement rules:
            // Ensure all map keys are strings.
            if (hclInput.Contains("{") && hclInput.Contains("=") && !hclInput.Contains("\""))
            {
                errors.Add("HCL v2 requires all map keys to be strings.");
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
        /// <param name="hclInput">The HCL input string to parse.</param>
        /// <returns>An object representing the parsed HCL document.</returns>
        /// <exception cref="Exception">Throws an exception if syntax errors are detected.</exception>
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
        /// Visits the document context and extracts all blocks.
        /// </summary>
        private List<object> VisitDocument(HclParser.DocumentContext context)
        {
            return context.block().Select(block => (object)VisitBlock(block)).ToList();
        }

        /// <summary>
        /// Visits a block and extracts its type, name, optional label, and body.
        /// </summary>
        private Dictionary<string, object?> VisitBlock(HclParser.BlockContext context)
        {
            var blockType = context.IDENTIFIER().GetText();
            var blockName = context.STRING(0)?.GetText()?.Trim('"');
            var optionalLabel = context.STRING(1)?.GetText()?.Trim('"');

            var body = VisitBody(context.body());
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
        private Dictionary<string, object?> VisitBody(HclParser.BodyContext context)
        {
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
                }
            }
            return bodyData;
        }

        /// <summary>
        /// Visits a map and extracts key-value pairs.
        /// Handles mixed value types including booleans, strings, and numbers.
        /// </summary>
        private Dictionary<string, object?> VisitMap(HclParser.MapContext context)
        {
            var map = new Dictionary<string, object?>();

            if (context?.mapEntry() == null)
            {
                throw new Exception("Map context or entries are null.");
            }

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

        /// <summary>
        /// Visits a value and returns its parsed representation.
        /// </summary>
        private object? VisitValue(HclParser.ValueContext context)
        {
            if (context.STRING() != null)
                return context.STRING().GetText().Trim('"');
            if (context.NUMBER() != null)
                return double.Parse(context.NUMBER().GetText());
            if (context.BOOL() != null)
                return context.BOOL().GetText() == "true";
            if (context.list() != null)
                return VisitList(context.list());
            if (context.map() != null)
                return VisitMap(context.map());
            if (context.reference() != null)
                return VisitReference(context.reference());
            if (context.interpolation() != null)
                return VisitInterpolation(context.interpolation());
            return null;
        }

        /// <summary>
        /// Visits a list and extracts its items.
        /// </summary>
        private List<object?> VisitList(HclParser.ListContext context)
        {
            return context.value().Select(VisitValue).ToList();
        }

        /// <summary>
        /// Visits a reference and constructs its textual representation.
        /// </summary>
        private string VisitReference(HclParser.ReferenceContext context)
        {
            var parts = new List<string>();

            // Add the first IDENTIFIER
            parts.Add(context.IDENTIFIER(0).GetText());

            // Traverse the remaining parts of the reference
            for (int i = 1; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);

                if (child is ITerminalNode terminal && terminal.GetText() == ".")
                {
                    continue; // Skip adding additional dots
                }
                else if (child is ITerminalNode terminalNode)
                {
                    parts.Add(terminalNode.GetText());
                }
                else if (child is HclParser.IndexedReferenceContext indexedReference)
                {
                    var key = indexedReference.GetChild(2).GetText(); // Either STRING or NUMBER
                    parts.Add($"[{key}]");

                    // Handle additional properties after indexed references
                    if (indexedReference.ChildCount > 4)
                    {
                        for (int j = 4; j < indexedReference.ChildCount; j += 2)
                        {
                            parts.Add(indexedReference.GetChild(j).GetText());
                        }
                    }
                }
            }

            return string.Join(".", parts);
        }

        private string VisitIndexedReference(HclParser.IndexedReferenceContext context)
        {
            var key = context.STRING().GetText().Trim('"');
            var parent = string.Join(".", context.IDENTIFIER().Select(id => id.GetText()));
            var additional = context.IDENTIFIER().Select(id => id.GetText());

            return $"{parent}[\"{key}\"]" + (additional.Any() ? $".{string.Join(".", additional)}" : string.Empty);
        }

        /// <summary>
        /// Visits an interpolation and extracts its text.
        /// </summary>
        private string VisitInterpolation(HclParser.InterpolationContext context)
        {
            return context.GetText();
        }
    }
}
