//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ./Hcl.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class HclLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, BOOL=9, 
		STRING=10, NUMBER=11, IDENTIFIER=12, COMMENT=13, WHITESPACE=14;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "BOOL", 
		"STRING", "NUMBER", "IDENTIFIER", "COMMENT", "WHITESPACE"
	};


	public HclLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public HclLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'{'", "'}'", "'='", "'['", "','", "']'", "'${'", "'.'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, "BOOL", "STRING", 
		"NUMBER", "IDENTIFIER", "COMMENT", "WHITESPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Hcl.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static HclLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,14,104,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,1,0,
		1,0,1,1,1,1,1,2,1,2,1,3,1,3,1,4,1,4,1,5,1,5,1,6,1,6,1,6,1,7,1,7,1,8,1,
		8,1,8,1,8,1,8,1,8,1,8,1,8,1,8,3,8,56,8,8,1,9,1,9,1,9,1,9,5,9,62,8,9,10,
		9,12,9,65,9,9,1,9,1,9,1,10,4,10,70,8,10,11,10,12,10,71,1,10,1,10,4,10,
		76,8,10,11,10,12,10,77,3,10,80,8,10,1,11,1,11,5,11,84,8,11,10,11,12,11,
		87,9,11,1,12,1,12,5,12,91,8,12,10,12,12,12,94,9,12,1,12,1,12,1,13,4,13,
		99,8,13,11,13,12,13,100,1,13,1,13,0,0,14,1,1,3,2,5,3,7,4,9,5,11,6,13,7,
		15,8,17,9,19,10,21,11,23,12,25,13,27,14,1,0,6,2,0,34,34,92,92,1,0,48,57,
		3,0,65,90,95,95,97,122,5,0,45,45,48,57,65,90,95,95,97,122,2,0,10,10,13,
		13,3,0,9,10,13,13,32,32,112,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,
		0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,
		0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,1,29,
		1,0,0,0,3,31,1,0,0,0,5,33,1,0,0,0,7,35,1,0,0,0,9,37,1,0,0,0,11,39,1,0,
		0,0,13,41,1,0,0,0,15,44,1,0,0,0,17,55,1,0,0,0,19,57,1,0,0,0,21,69,1,0,
		0,0,23,81,1,0,0,0,25,88,1,0,0,0,27,98,1,0,0,0,29,30,5,123,0,0,30,2,1,0,
		0,0,31,32,5,125,0,0,32,4,1,0,0,0,33,34,5,61,0,0,34,6,1,0,0,0,35,36,5,91,
		0,0,36,8,1,0,0,0,37,38,5,44,0,0,38,10,1,0,0,0,39,40,5,93,0,0,40,12,1,0,
		0,0,41,42,5,36,0,0,42,43,5,123,0,0,43,14,1,0,0,0,44,45,5,46,0,0,45,16,
		1,0,0,0,46,47,5,116,0,0,47,48,5,114,0,0,48,49,5,117,0,0,49,56,5,101,0,
		0,50,51,5,102,0,0,51,52,5,97,0,0,52,53,5,108,0,0,53,54,5,115,0,0,54,56,
		5,101,0,0,55,46,1,0,0,0,55,50,1,0,0,0,56,18,1,0,0,0,57,63,5,34,0,0,58,
		62,8,0,0,0,59,60,5,92,0,0,60,62,9,0,0,0,61,58,1,0,0,0,61,59,1,0,0,0,62,
		65,1,0,0,0,63,61,1,0,0,0,63,64,1,0,0,0,64,66,1,0,0,0,65,63,1,0,0,0,66,
		67,5,34,0,0,67,20,1,0,0,0,68,70,7,1,0,0,69,68,1,0,0,0,70,71,1,0,0,0,71,
		69,1,0,0,0,71,72,1,0,0,0,72,79,1,0,0,0,73,75,5,46,0,0,74,76,7,1,0,0,75,
		74,1,0,0,0,76,77,1,0,0,0,77,75,1,0,0,0,77,78,1,0,0,0,78,80,1,0,0,0,79,
		73,1,0,0,0,79,80,1,0,0,0,80,22,1,0,0,0,81,85,7,2,0,0,82,84,7,3,0,0,83,
		82,1,0,0,0,84,87,1,0,0,0,85,83,1,0,0,0,85,86,1,0,0,0,86,24,1,0,0,0,87,
		85,1,0,0,0,88,92,5,35,0,0,89,91,8,4,0,0,90,89,1,0,0,0,91,94,1,0,0,0,92,
		90,1,0,0,0,92,93,1,0,0,0,93,95,1,0,0,0,94,92,1,0,0,0,95,96,6,12,0,0,96,
		26,1,0,0,0,97,99,7,5,0,0,98,97,1,0,0,0,99,100,1,0,0,0,100,98,1,0,0,0,100,
		101,1,0,0,0,101,102,1,0,0,0,102,103,6,13,0,0,103,28,1,0,0,0,10,0,55,61,
		63,71,77,79,85,92,100,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}