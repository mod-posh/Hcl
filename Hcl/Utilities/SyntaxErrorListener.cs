using Antlr4.Runtime;
using System.Collections.Generic;

namespace ModPosh.Hcl.Utilities
{
    public class SyntaxErrorListener : IAntlrErrorListener<IToken>
    {
        private readonly List<string> errors = new List<string>();

        public bool HasErrors => errors.Count > 0;

        public string GetErrors() => string.Join("\n", errors);

        public List<string> GetErrorsList() => new List<string>(errors);

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var offendingToken = offendingSymbol?.Text ?? "unknown";
            errors.Add($"Line {line}:{charPositionInLine} {msg}. Offending token: {offendingToken}");
        }
    }
}
