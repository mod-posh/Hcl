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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public partial class HclParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, BOOL=9, 
		STRING=10, NUMBER=11, IDENTIFIER=12, COMMENT=13, WHITESPACE=14;
	public const int
		RULE_document = 0, RULE_block = 1, RULE_body = 2, RULE_attribute = 3, 
		RULE_value = 4, RULE_list = 5, RULE_map = 6, RULE_mapEntry = 7, RULE_interpolation = 8;
	public static readonly string[] ruleNames = {
		"document", "block", "body", "attribute", "value", "list", "map", "mapEntry", 
		"interpolation"
	};

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

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static HclParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public HclParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public HclParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class DocumentContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode Eof() { return GetToken(HclParser.Eof, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public BlockContext[] block() {
			return GetRuleContexts<BlockContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public BlockContext block(int i) {
			return GetRuleContext<BlockContext>(i);
		}
		public DocumentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_document; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterDocument(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitDocument(this);
		}
	}

	[RuleVersion(0)]
	public DocumentContext document() {
		DocumentContext _localctx = new DocumentContext(Context, State);
		EnterRule(_localctx, 0, RULE_document);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 21;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==IDENTIFIER) {
				{
				{
				State = 18;
				block();
				}
				}
				State = 23;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 24;
			Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(HclParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(HclParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public BodyContext body() {
			return GetRuleContext<BodyContext>(0);
		}
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_block; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(Context, State);
		EnterRule(_localctx, 2, RULE_block);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			Match(IDENTIFIER);
			State = 27;
			Match(STRING);
			State = 28;
			Match(T__0);
			State = 29;
			body();
			State = 30;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BodyContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public AttributeContext[] attribute() {
			return GetRuleContexts<AttributeContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public AttributeContext attribute(int i) {
			return GetRuleContext<AttributeContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMENT() { return GetTokens(HclParser.COMMENT); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMENT(int i) {
			return GetToken(HclParser.COMMENT, i);
		}
		public BodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_body; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterBody(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitBody(this);
		}
	}

	[RuleVersion(0)]
	public BodyContext body() {
		BodyContext _localctx = new BodyContext(Context, State);
		EnterRule(_localctx, 4, RULE_body);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==IDENTIFIER || _la==COMMENT) {
				{
				State = 34;
				ErrorHandler.Sync(this);
				switch (TokenStream.LA(1)) {
				case IDENTIFIER:
					{
					State = 32;
					attribute();
					}
					break;
				case COMMENT:
					{
					State = 33;
					Match(COMMENT);
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				State = 38;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AttributeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(HclParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public AttributeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_attribute; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterAttribute(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitAttribute(this);
		}
	}

	[RuleVersion(0)]
	public AttributeContext attribute() {
		AttributeContext _localctx = new AttributeContext(Context, State);
		EnterRule(_localctx, 6, RULE_attribute);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			Match(IDENTIFIER);
			State = 40;
			Match(T__2);
			State = 41;
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode BOOL() { return GetToken(HclParser.BOOL, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING() { return GetToken(HclParser.STRING, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUMBER() { return GetToken(HclParser.NUMBER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ListContext list() {
			return GetRuleContext<ListContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public MapContext map() {
			return GetRuleContext<MapContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public InterpolationContext interpolation() {
			return GetRuleContext<InterpolationContext>(0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterValue(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitValue(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 8, RULE_value);
		try {
			State = 49;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case BOOL:
				EnterOuterAlt(_localctx, 1);
				{
				State = 43;
				Match(BOOL);
				}
				break;
			case STRING:
				EnterOuterAlt(_localctx, 2);
				{
				State = 44;
				Match(STRING);
				}
				break;
			case NUMBER:
				EnterOuterAlt(_localctx, 3);
				{
				State = 45;
				Match(NUMBER);
				}
				break;
			case T__3:
				EnterOuterAlt(_localctx, 4);
				{
				State = 46;
				list();
				}
				break;
			case T__0:
				EnterOuterAlt(_localctx, 5);
				{
				State = 47;
				map();
				}
				break;
			case T__6:
				EnterOuterAlt(_localctx, 6);
				{
				State = 48;
				interpolation();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ListContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext[] value() {
			return GetRuleContexts<ValueContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value(int i) {
			return GetRuleContext<ValueContext>(i);
		}
		public ListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_list; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterList(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitList(this);
		}
	}

	[RuleVersion(0)]
	public ListContext list() {
		ListContext _localctx = new ListContext(Context, State);
		EnterRule(_localctx, 10, RULE_list);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 51;
			Match(T__3);
			State = 60;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 3730L) != 0)) {
				{
				State = 52;
				value();
				State = 57;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__4) {
					{
					{
					State = 53;
					Match(T__4);
					State = 54;
					value();
					}
					}
					State = 59;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
			}

			State = 62;
			Match(T__5);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MapContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public MapEntryContext[] mapEntry() {
			return GetRuleContexts<MapEntryContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public MapEntryContext mapEntry(int i) {
			return GetRuleContext<MapEntryContext>(i);
		}
		public MapContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_map; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterMap(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitMap(this);
		}
	}

	[RuleVersion(0)]
	public MapContext map() {
		MapContext _localctx = new MapContext(Context, State);
		EnterRule(_localctx, 12, RULE_map);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 64;
			Match(T__0);
			State = 73;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==IDENTIFIER) {
				{
				State = 65;
				mapEntry();
				State = 70;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				while (_la==T__4) {
					{
					{
					State = 66;
					Match(T__4);
					State = 67;
					mapEntry();
					}
					}
					State = 72;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
				}
				}
			}

			State = 75;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MapEntryContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(HclParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public MapEntryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_mapEntry; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterMapEntry(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitMapEntry(this);
		}
	}

	[RuleVersion(0)]
	public MapEntryContext mapEntry() {
		MapEntryContext _localctx = new MapEntryContext(Context, State);
		EnterRule(_localctx, 14, RULE_mapEntry);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77;
			Match(IDENTIFIER);
			State = 78;
			Match(T__2);
			State = 79;
			value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class InterpolationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] IDENTIFIER() { return GetTokens(HclParser.IDENTIFIER); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER(int i) {
			return GetToken(HclParser.IDENTIFIER, i);
		}
		public InterpolationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_interpolation; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.EnterInterpolation(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IHclListener typedListener = listener as IHclListener;
			if (typedListener != null) typedListener.ExitInterpolation(this);
		}
	}

	[RuleVersion(0)]
	public InterpolationContext interpolation() {
		InterpolationContext _localctx = new InterpolationContext(Context, State);
		EnterRule(_localctx, 16, RULE_interpolation);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 81;
			Match(T__6);
			State = 82;
			Match(IDENTIFIER);
			State = 87;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==T__7) {
				{
				{
				State = 83;
				Match(T__7);
				State = 84;
				Match(IDENTIFIER);
				}
				}
				State = 89;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 90;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,14,93,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,1,0,5,0,20,8,0,10,0,12,0,23,9,0,1,0,1,0,1,1,1,1,1,1,1,1,1,
		1,1,1,1,2,1,2,5,2,35,8,2,10,2,12,2,38,9,2,1,3,1,3,1,3,1,3,1,4,1,4,1,4,
		1,4,1,4,1,4,3,4,50,8,4,1,5,1,5,1,5,1,5,5,5,56,8,5,10,5,12,5,59,9,5,3,5,
		61,8,5,1,5,1,5,1,6,1,6,1,6,1,6,5,6,69,8,6,10,6,12,6,72,9,6,3,6,74,8,6,
		1,6,1,6,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,5,8,86,8,8,10,8,12,8,89,9,8,1,
		8,1,8,1,8,0,0,9,0,2,4,6,8,10,12,14,16,0,0,96,0,21,1,0,0,0,2,26,1,0,0,0,
		4,36,1,0,0,0,6,39,1,0,0,0,8,49,1,0,0,0,10,51,1,0,0,0,12,64,1,0,0,0,14,
		77,1,0,0,0,16,81,1,0,0,0,18,20,3,2,1,0,19,18,1,0,0,0,20,23,1,0,0,0,21,
		19,1,0,0,0,21,22,1,0,0,0,22,24,1,0,0,0,23,21,1,0,0,0,24,25,5,0,0,1,25,
		1,1,0,0,0,26,27,5,12,0,0,27,28,5,10,0,0,28,29,5,1,0,0,29,30,3,4,2,0,30,
		31,5,2,0,0,31,3,1,0,0,0,32,35,3,6,3,0,33,35,5,13,0,0,34,32,1,0,0,0,34,
		33,1,0,0,0,35,38,1,0,0,0,36,34,1,0,0,0,36,37,1,0,0,0,37,5,1,0,0,0,38,36,
		1,0,0,0,39,40,5,12,0,0,40,41,5,3,0,0,41,42,3,8,4,0,42,7,1,0,0,0,43,50,
		5,9,0,0,44,50,5,10,0,0,45,50,5,11,0,0,46,50,3,10,5,0,47,50,3,12,6,0,48,
		50,3,16,8,0,49,43,1,0,0,0,49,44,1,0,0,0,49,45,1,0,0,0,49,46,1,0,0,0,49,
		47,1,0,0,0,49,48,1,0,0,0,50,9,1,0,0,0,51,60,5,4,0,0,52,57,3,8,4,0,53,54,
		5,5,0,0,54,56,3,8,4,0,55,53,1,0,0,0,56,59,1,0,0,0,57,55,1,0,0,0,57,58,
		1,0,0,0,58,61,1,0,0,0,59,57,1,0,0,0,60,52,1,0,0,0,60,61,1,0,0,0,61,62,
		1,0,0,0,62,63,5,6,0,0,63,11,1,0,0,0,64,73,5,1,0,0,65,70,3,14,7,0,66,67,
		5,5,0,0,67,69,3,14,7,0,68,66,1,0,0,0,69,72,1,0,0,0,70,68,1,0,0,0,70,71,
		1,0,0,0,71,74,1,0,0,0,72,70,1,0,0,0,73,65,1,0,0,0,73,74,1,0,0,0,74,75,
		1,0,0,0,75,76,5,2,0,0,76,13,1,0,0,0,77,78,5,12,0,0,78,79,5,3,0,0,79,80,
		3,8,4,0,80,15,1,0,0,0,81,82,5,7,0,0,82,87,5,12,0,0,83,84,5,8,0,0,84,86,
		5,12,0,0,85,83,1,0,0,0,86,89,1,0,0,0,87,85,1,0,0,0,87,88,1,0,0,0,88,90,
		1,0,0,0,89,87,1,0,0,0,90,91,5,2,0,0,91,17,1,0,0,0,9,21,34,36,49,57,60,
		70,73,87
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
