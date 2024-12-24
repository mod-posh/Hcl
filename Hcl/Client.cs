using Antlr4.Runtime;
using ModPosh.Hcl.Utilities;
using ModPosh.Hcl.Models;
using System;
using System.Collections.Generic;

namespace ModPosh.Hcl
{
    /// <summary>
    /// Client class for validating and parsing HCL input.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Validates the provided HCL input for syntax errors.
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

            return new ValidationResult
            {
                IsValid = !errorListener.HasErrors,
                Errors = errorListener.GetErrorsList()
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
        /// <param name="context">The document context from the parser.</param>
        /// <returns>A list of parsed blocks.</returns>
        private List<object> VisitDocument(HclParser.DocumentContext context)
        {
            var blocks = new List<object>();
            foreach (var block in context.block())
            {
                blocks.Add(VisitBlock(block));
            }
            return blocks;
        }

        /// <summary>
        /// Visits a block and extracts its type, name, optional label, and body.
        /// </summary>
        /// <param name="context">The block context from the parser.</param>
        /// <returns>A dictionary representing the block's data.</returns>
        private Dictionary<string, object?> VisitBlock(HclParser.BlockContext context)
        {
            var blockData = new Dictionary<string, object?>
            {
                ["type"] = context.IDENTIFIER().GetText(),
                ["name"] = context.STRING(0).GetText().Trim('"'),
                ["optionalLabel"] = context.STRING(1)?.GetText()?.Trim('"'),
                ["body"] = VisitBody(context.body())
            };
            return blockData;
        }

        /// <summary>
        /// Visits the body of a block and extracts all attributes and nested blocks.
        /// </summary>
        /// <param name="context">The body context from the parser.</param>
        /// <returns>A dictionary representing the attributes and nested blocks.</returns>
        private Dictionary<string, object?> VisitBody(HclParser.BodyContext context)
        {
            var bodyData = new Dictionary<string, object?>();

            foreach (var attr in context.attribute())
            {
                bodyData[attr.IDENTIFIER().GetText()] = VisitValue(attr.value());
            }

            foreach (var nested in context.nestedBlock())
            {
                bodyData[nested.IDENTIFIER().GetText()] = VisitBody(nested.body());
            }

            return bodyData;
        }

        /// <summary>
        /// Visits a value and returns its parsed representation.
        /// </summary>
        /// <param name="context">The value context from the parser.</param>
        /// <returns>The parsed value as an object.</returns>
        private object? VisitValue(HclParser.ValueContext context)
        {
            if (context.STRING() != null)
                return context.STRING().GetText().Trim('"');
            if (context.NUMBER() != null)
                return double.Parse(context.NUMBER().GetText());
            if (context.BOOL() != null)
                return context.BOOL().GetText() == "true"; // Explicit handling for BOOL
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
        /// Visits a reference and constructs its textual representation.
        /// </summary>
        /// <param name="context">The reference context from the parser.</param>
        /// <returns>The reference text as a string.</returns>
        private string VisitReference(HclParser.ReferenceContext context)
        {
            return string.Join(".", context.IDENTIFIER().Select(id => id.GetText()));
        }

        /// <summary>
        /// Visits a list and extracts its items.
        /// </summary>
        /// <param name="context">The list context from the parser.</param>
        /// <returns>A list of parsed items.</returns>
        private List<object?> VisitList(HclParser.ListContext context)
        {
            var items = new List<object?>();
            foreach (var value in context.value())
            {
                items.Add(VisitValue(value));
            }
            return items;
        }

        /// <summary>
        /// Visits a map and extracts key-value pairs.
        /// </summary>
        /// <param name="context">The map context from the parser.</param>
        /// <returns>A dictionary representing the map.</returns>
        private Dictionary<string, object?> VisitMap(HclParser.MapContext context)
        {
            var map = new Dictionary<string, object?>();
            foreach (var entry in context.mapEntry())
            {
                var key = entry.STRING()?.GetText()?.Trim('"') ?? entry.IDENTIFIER()?.GetText();
                if (key != null)
                {
                    map[key] = VisitValue(entry.value());
                }
            }
            return map;
        }

        /// <summary>
        /// Visits an interpolation and extracts its text.
        /// </summary>
        /// <param name="context">The interpolation context from the parser.</param>
        /// <returns>The interpolation text as a string.</returns>
        private string VisitInterpolation(HclParser.InterpolationContext context)
        {
            return context.GetText();
        }
    }
}
