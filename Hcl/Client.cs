using Antlr4.Runtime;
using ModPosh.Hcl.Utilities;
using ModPosh.Hcl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return new Dictionary<string, object?>
            {
                ["type"] = context.IDENTIFIER().GetText(),
                ["name"] = context.STRING(0).GetText().Trim('"'),
                ["optionalLabel"] = context.STRING(1)?.GetText()?.Trim('"'),
                ["body"] = VisitBody(context.body())
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
                if (element is HclParser.AttributeContext attr)
                {
                    if (attr.indexedAttribute() != null)
                    {
                        var indexedAttr = attr.indexedAttribute();
                        var parentKey = indexedAttr.IDENTIFIER().GetText();
                        var indexKey = indexedAttr.STRING().GetText().Trim('"');
                        var fullKey = $"{parentKey}[\"{indexKey}\"]";
                        bodyData[fullKey] = VisitValue(attr.value());
                    }
                    else
                    {
                        bodyData[attr.IDENTIFIER().GetText()] = VisitValue(attr.value());
                    }
                }
                else if (element is HclParser.NestedBlockContext nested)
                {
                    bodyData[nested.IDENTIFIER().GetText()] = VisitBody(nested.body());
                }
                // Ignore comments and newlines
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
                // Handle empty maps gracefully
                return map;
            }

            foreach (var entry in context.mapEntry())
            {
                var key = entry.mapKey().STRING()?.GetText()?.Trim('"')
                         ?? entry.mapKey().IDENTIFIER()?.GetText();

                if (key == null)
                {
                    throw new Exception($"Invalid or missing key in map entry: {entry.GetText()}");
                }

                map[key] = VisitValue(entry.value());
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
            return string.Join(".", context.IDENTIFIER().Select(id => id.GetText()));
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
