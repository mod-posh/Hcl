// Generated from d:/CODE/Organizations/mod-posh/Hcl/Hcl/Hcl.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link HclParser}.
 */
public interface HclListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link HclParser#document}.
	 * @param ctx the parse tree
	 */
	void enterDocument(HclParser.DocumentContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#document}.
	 * @param ctx the parse tree
	 */
	void exitDocument(HclParser.DocumentContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(HclParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(HclParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#body}.
	 * @param ctx the parse tree
	 */
	void enterBody(HclParser.BodyContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#body}.
	 * @param ctx the parse tree
	 */
	void exitBody(HclParser.BodyContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#attribute}.
	 * @param ctx the parse tree
	 */
	void enterAttribute(HclParser.AttributeContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#attribute}.
	 * @param ctx the parse tree
	 */
	void exitAttribute(HclParser.AttributeContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#nestedBlock}.
	 * @param ctx the parse tree
	 */
	void enterNestedBlock(HclParser.NestedBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#nestedBlock}.
	 * @param ctx the parse tree
	 */
	void exitNestedBlock(HclParser.NestedBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(HclParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(HclParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#key}.
	 * @param ctx the parse tree
	 */
	void enterKey(HclParser.KeyContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#key}.
	 * @param ctx the parse tree
	 */
	void exitKey(HclParser.KeyContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#list}.
	 * @param ctx the parse tree
	 */
	void enterList(HclParser.ListContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#list}.
	 * @param ctx the parse tree
	 */
	void exitList(HclParser.ListContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#map}.
	 * @param ctx the parse tree
	 */
	void enterMap(HclParser.MapContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#map}.
	 * @param ctx the parse tree
	 */
	void exitMap(HclParser.MapContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#mapEntry}.
	 * @param ctx the parse tree
	 */
	void enterMapEntry(HclParser.MapEntryContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#mapEntry}.
	 * @param ctx the parse tree
	 */
	void exitMapEntry(HclParser.MapEntryContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(HclParser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(HclParser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#reference}.
	 * @param ctx the parse tree
	 */
	void enterReference(HclParser.ReferenceContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#reference}.
	 * @param ctx the parse tree
	 */
	void exitReference(HclParser.ReferenceContext ctx);
	/**
	 * Enter a parse tree produced by {@link HclParser#interpolation}.
	 * @param ctx the parse tree
	 */
	void enterInterpolation(HclParser.InterpolationContext ctx);
	/**
	 * Exit a parse tree produced by {@link HclParser#interpolation}.
	 * @param ctx the parse tree
	 */
	void exitInterpolation(HclParser.InterpolationContext ctx);
}