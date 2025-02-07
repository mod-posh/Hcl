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


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IHclListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class HclBaseListener : IHclListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.document"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDocument([NotNull] HclParser.DocumentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.document"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDocument([NotNull] HclParser.DocumentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlock([NotNull] HclParser.BlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.block"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlock([NotNull] HclParser.BlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.blockLabel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBlockLabel([NotNull] HclParser.BlockLabelContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.blockLabel"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBlockLabel([NotNull] HclParser.BlockLabelContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.body"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBody([NotNull] HclParser.BodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.body"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBody([NotNull] HclParser.BodyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAttribute([NotNull] HclParser.AttributeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.attribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAttribute([NotNull] HclParser.AttributeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.nestedBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNestedBlock([NotNull] HclParser.NestedBlockContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.nestedBlock"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNestedBlock([NotNull] HclParser.NestedBlockContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.indexedAttribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndexedAttribute([NotNull] HclParser.IndexedAttributeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.indexedAttribute"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndexedAttribute([NotNull] HclParser.IndexedAttributeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterList([NotNull] HclParser.ListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.list"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitList([NotNull] HclParser.ListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.map"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMap([NotNull] HclParser.MapContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.map"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMap([NotNull] HclParser.MapContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.mapEntry"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMapEntry([NotNull] HclParser.MapEntryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.mapEntry"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMapEntry([NotNull] HclParser.MapEntryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.mapKey"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMapKey([NotNull] HclParser.MapKeyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.mapKey"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMapKey([NotNull] HclParser.MapKeyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.multilineString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultilineString([NotNull] HclParser.MultilineStringContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.multilineString"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultilineString([NotNull] HclParser.MultilineStringContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] HclParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] HclParser.ValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.interpolation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterInterpolation([NotNull] HclParser.InterpolationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.interpolation"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitInterpolation([NotNull] HclParser.InterpolationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReference([NotNull] HclParser.ReferenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.reference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReference([NotNull] HclParser.ReferenceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.indexedReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndexedReference([NotNull] HclParser.IndexedReferenceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.indexedReference"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndexedReference([NotNull] HclParser.IndexedReferenceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCall([NotNull] HclParser.FunctionCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCall([NotNull] HclParser.FunctionCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="HclParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] HclParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="HclParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] HclParser.ExpressionContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
