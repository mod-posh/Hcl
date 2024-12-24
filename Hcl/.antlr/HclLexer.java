// Generated from d:/CODE/Organizations/mod-posh/Hcl/Hcl/Hcl.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue", "this-escape"})
public class HclLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, IDENTIFIER=12, STRING=13, QUOTED_KEY=14, HEREDOC=15, 
		NUMBER=16, BOOL=17, WHITESPACE=18, COMMENT=19, MULTILINE_COMMENT=20;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "T__10", "IDENTIFIER", "STRING", "QUOTED_KEY", "HEREDOC", "NUMBER", 
			"BOOL", "WHITESPACE", "COMMENT", "MULTILINE_COMMENT"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'{'", "'}'", "'='", "'['", "','", "']'", "'('", "')'", "'.'", 
			"'.*'", "'${'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			"IDENTIFIER", "STRING", "QUOTED_KEY", "HEREDOC", "NUMBER", "BOOL", "WHITESPACE", 
			"COMMENT", "MULTILINE_COMMENT"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public HclLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Hcl.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\u0004\u0000\u0014\u00a6\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002"+
		"\u0001\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002"+
		"\u0004\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002"+
		"\u0007\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002"+
		"\u000b\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e"+
		"\u0002\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011"+
		"\u0002\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003"+
		"\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006"+
		"\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\t\u0001\t\u0001\t\u0001"+
		"\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0005\u000bD\b\u000b\n\u000b"+
		"\f\u000bG\t\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0005\fM\b\f\n\f\f\f"+
		"P\t\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001\r\u0001\r\u0005\rX\b\r\n\r"+
		"\f\r[\t\r\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0003\u000ec\b\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0005\u000e"+
		"h\b\u000e\n\u000e\f\u000ek\t\u000e\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0001\u000e\u0001\u000f\u0004\u000fr\b\u000f\u000b\u000f\f\u000fs\u0001"+
		"\u000f\u0001\u000f\u0004\u000fx\b\u000f\u000b\u000f\f\u000fy\u0003\u000f"+
		"|\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0003\u0010\u0087\b\u0010"+
		"\u0001\u0011\u0004\u0011\u008a\b\u0011\u000b\u0011\f\u0011\u008b\u0001"+
		"\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0005\u0012\u0092\b\u0012\n"+
		"\u0012\f\u0012\u0095\t\u0012\u0001\u0012\u0001\u0012\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0005\u0013\u009d\b\u0013\n\u0013\f\u0013"+
		"\u00a0\t\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013"+
		"\u0002i\u009e\u0000\u0014\u0001\u0001\u0003\u0002\u0005\u0003\u0007\u0004"+
		"\t\u0005\u000b\u0006\r\u0007\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017"+
		"\f\u0019\r\u001b\u000e\u001d\u000f\u001f\u0010!\u0011#\u0012%\u0013\'"+
		"\u0014\u0001\u0000\u0006\u0003\u0000AZ__az\u0005\u0000--09AZ__az\u0002"+
		"\u0000\"\"\\\\\u0001\u000009\u0003\u0000\t\n\r\r  \u0002\u0000\n\n\r\r"+
		"\u00b3\u0000\u0001\u0001\u0000\u0000\u0000\u0000\u0003\u0001\u0000\u0000"+
		"\u0000\u0000\u0005\u0001\u0000\u0000\u0000\u0000\u0007\u0001\u0000\u0000"+
		"\u0000\u0000\t\u0001\u0000\u0000\u0000\u0000\u000b\u0001\u0000\u0000\u0000"+
		"\u0000\r\u0001\u0000\u0000\u0000\u0000\u000f\u0001\u0000\u0000\u0000\u0000"+
		"\u0011\u0001\u0000\u0000\u0000\u0000\u0013\u0001\u0000\u0000\u0000\u0000"+
		"\u0015\u0001\u0000\u0000\u0000\u0000\u0017\u0001\u0000\u0000\u0000\u0000"+
		"\u0019\u0001\u0000\u0000\u0000\u0000\u001b\u0001\u0000\u0000\u0000\u0000"+
		"\u001d\u0001\u0000\u0000\u0000\u0000\u001f\u0001\u0000\u0000\u0000\u0000"+
		"!\u0001\u0000\u0000\u0000\u0000#\u0001\u0000\u0000\u0000\u0000%\u0001"+
		"\u0000\u0000\u0000\u0000\'\u0001\u0000\u0000\u0000\u0001)\u0001\u0000"+
		"\u0000\u0000\u0003+\u0001\u0000\u0000\u0000\u0005-\u0001\u0000\u0000\u0000"+
		"\u0007/\u0001\u0000\u0000\u0000\t1\u0001\u0000\u0000\u0000\u000b3\u0001"+
		"\u0000\u0000\u0000\r5\u0001\u0000\u0000\u0000\u000f7\u0001\u0000\u0000"+
		"\u0000\u00119\u0001\u0000\u0000\u0000\u0013;\u0001\u0000\u0000\u0000\u0015"+
		">\u0001\u0000\u0000\u0000\u0017A\u0001\u0000\u0000\u0000\u0019H\u0001"+
		"\u0000\u0000\u0000\u001bS\u0001\u0000\u0000\u0000\u001d^\u0001\u0000\u0000"+
		"\u0000\u001fq\u0001\u0000\u0000\u0000!\u0086\u0001\u0000\u0000\u0000#"+
		"\u0089\u0001\u0000\u0000\u0000%\u008f\u0001\u0000\u0000\u0000\'\u0098"+
		"\u0001\u0000\u0000\u0000)*\u0005{\u0000\u0000*\u0002\u0001\u0000\u0000"+
		"\u0000+,\u0005}\u0000\u0000,\u0004\u0001\u0000\u0000\u0000-.\u0005=\u0000"+
		"\u0000.\u0006\u0001\u0000\u0000\u0000/0\u0005[\u0000\u00000\b\u0001\u0000"+
		"\u0000\u000012\u0005,\u0000\u00002\n\u0001\u0000\u0000\u000034\u0005]"+
		"\u0000\u00004\f\u0001\u0000\u0000\u000056\u0005(\u0000\u00006\u000e\u0001"+
		"\u0000\u0000\u000078\u0005)\u0000\u00008\u0010\u0001\u0000\u0000\u0000"+
		"9:\u0005.\u0000\u0000:\u0012\u0001\u0000\u0000\u0000;<\u0005.\u0000\u0000"+
		"<=\u0005*\u0000\u0000=\u0014\u0001\u0000\u0000\u0000>?\u0005$\u0000\u0000"+
		"?@\u0005{\u0000\u0000@\u0016\u0001\u0000\u0000\u0000AE\u0007\u0000\u0000"+
		"\u0000BD\u0007\u0001\u0000\u0000CB\u0001\u0000\u0000\u0000DG\u0001\u0000"+
		"\u0000\u0000EC\u0001\u0000\u0000\u0000EF\u0001\u0000\u0000\u0000F\u0018"+
		"\u0001\u0000\u0000\u0000GE\u0001\u0000\u0000\u0000HN\u0005\"\u0000\u0000"+
		"IM\b\u0002\u0000\u0000JK\u0005\\\u0000\u0000KM\t\u0000\u0000\u0000LI\u0001"+
		"\u0000\u0000\u0000LJ\u0001\u0000\u0000\u0000MP\u0001\u0000\u0000\u0000"+
		"NL\u0001\u0000\u0000\u0000NO\u0001\u0000\u0000\u0000OQ\u0001\u0000\u0000"+
		"\u0000PN\u0001\u0000\u0000\u0000QR\u0005\"\u0000\u0000R\u001a\u0001\u0000"+
		"\u0000\u0000SY\u0005\"\u0000\u0000TX\b\u0002\u0000\u0000UV\u0005\\\u0000"+
		"\u0000VX\t\u0000\u0000\u0000WT\u0001\u0000\u0000\u0000WU\u0001\u0000\u0000"+
		"\u0000X[\u0001\u0000\u0000\u0000YW\u0001\u0000\u0000\u0000YZ\u0001\u0000"+
		"\u0000\u0000Z\\\u0001\u0000\u0000\u0000[Y\u0001\u0000\u0000\u0000\\]\u0005"+
		"\"\u0000\u0000]\u001c\u0001\u0000\u0000\u0000^_\u0005<\u0000\u0000_`\u0005"+
		"<\u0000\u0000`b\u0001\u0000\u0000\u0000ac\u0005-\u0000\u0000ba\u0001\u0000"+
		"\u0000\u0000bc\u0001\u0000\u0000\u0000cd\u0001\u0000\u0000\u0000de\u0003"+
		"\u0017\u000b\u0000ei\u0005\n\u0000\u0000fh\t\u0000\u0000\u0000gf\u0001"+
		"\u0000\u0000\u0000hk\u0001\u0000\u0000\u0000ij\u0001\u0000\u0000\u0000"+
		"ig\u0001\u0000\u0000\u0000jl\u0001\u0000\u0000\u0000ki\u0001\u0000\u0000"+
		"\u0000lm\u0005\n\u0000\u0000mn\u0003\u0017\u000b\u0000no\u0005\n\u0000"+
		"\u0000o\u001e\u0001\u0000\u0000\u0000pr\u0007\u0003\u0000\u0000qp\u0001"+
		"\u0000\u0000\u0000rs\u0001\u0000\u0000\u0000sq\u0001\u0000\u0000\u0000"+
		"st\u0001\u0000\u0000\u0000t{\u0001\u0000\u0000\u0000uw\u0005.\u0000\u0000"+
		"vx\u0007\u0003\u0000\u0000wv\u0001\u0000\u0000\u0000xy\u0001\u0000\u0000"+
		"\u0000yw\u0001\u0000\u0000\u0000yz\u0001\u0000\u0000\u0000z|\u0001\u0000"+
		"\u0000\u0000{u\u0001\u0000\u0000\u0000{|\u0001\u0000\u0000\u0000| \u0001"+
		"\u0000\u0000\u0000}~\u0005t\u0000\u0000~\u007f\u0005r\u0000\u0000\u007f"+
		"\u0080\u0005u\u0000\u0000\u0080\u0087\u0005e\u0000\u0000\u0081\u0082\u0005"+
		"f\u0000\u0000\u0082\u0083\u0005a\u0000\u0000\u0083\u0084\u0005l\u0000"+
		"\u0000\u0084\u0085\u0005s\u0000\u0000\u0085\u0087\u0005e\u0000\u0000\u0086"+
		"}\u0001\u0000\u0000\u0000\u0086\u0081\u0001\u0000\u0000\u0000\u0087\""+
		"\u0001\u0000\u0000\u0000\u0088\u008a\u0007\u0004\u0000\u0000\u0089\u0088"+
		"\u0001\u0000\u0000\u0000\u008a\u008b\u0001\u0000\u0000\u0000\u008b\u0089"+
		"\u0001\u0000\u0000\u0000\u008b\u008c\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0001\u0000\u0000\u0000\u008d\u008e\u0006\u0011\u0000\u0000\u008e$\u0001"+
		"\u0000\u0000\u0000\u008f\u0093\u0005#\u0000\u0000\u0090\u0092\b\u0005"+
		"\u0000\u0000\u0091\u0090\u0001\u0000\u0000\u0000\u0092\u0095\u0001\u0000"+
		"\u0000\u0000\u0093\u0091\u0001\u0000\u0000\u0000\u0093\u0094\u0001\u0000"+
		"\u0000\u0000\u0094\u0096\u0001\u0000\u0000\u0000\u0095\u0093\u0001\u0000"+
		"\u0000\u0000\u0096\u0097\u0006\u0012\u0000\u0000\u0097&\u0001\u0000\u0000"+
		"\u0000\u0098\u0099\u0005/\u0000\u0000\u0099\u009a\u0005*\u0000\u0000\u009a"+
		"\u009e\u0001\u0000\u0000\u0000\u009b\u009d\t\u0000\u0000\u0000\u009c\u009b"+
		"\u0001\u0000\u0000\u0000\u009d\u00a0\u0001\u0000\u0000\u0000\u009e\u009f"+
		"\u0001\u0000\u0000\u0000\u009e\u009c\u0001\u0000\u0000\u0000\u009f\u00a1"+
		"\u0001\u0000\u0000\u0000\u00a0\u009e\u0001\u0000\u0000\u0000\u00a1\u00a2"+
		"\u0005*\u0000\u0000\u00a2\u00a3\u0005/\u0000\u0000\u00a3\u00a4\u0001\u0000"+
		"\u0000\u0000\u00a4\u00a5\u0006\u0013\u0000\u0000\u00a5(\u0001\u0000\u0000"+
		"\u0000\u000f\u0000ELNWYbisy{\u0086\u008b\u0093\u009e\u0001\u0006\u0000"+
		"\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}