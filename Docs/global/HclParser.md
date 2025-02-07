# HclParser class

```csharp
public class HclParser : Parser
```

## Public Members

| name | description |
| --- | --- |
| [HclParser](HclParser/HclParser.md)(…) |  (2 constructors) |
| override [GrammarFileName](HclParser/GrammarFileName.md) { get; } |  |
| override [RuleNames](HclParser/RuleNames.md) { get; } |  |
| override [SerializedAtn](HclParser/SerializedAtn.md) { get; } |  |
| override [Vocabulary](HclParser/Vocabulary.md) { get; } |  |
| [attribute](HclParser/attribute.md)() |  |
| [block](HclParser/block.md)() |  |
| [blockLabel](HclParser/blockLabel.md)() |  |
| [body](HclParser/body.md)() |  |
| [document](HclParser/document.md)() |  |
| [expression](HclParser/expression.md)() |  |
| [functionCall](HclParser/functionCall.md)() |  |
| [indexedAttribute](HclParser/indexedAttribute.md)() |  |
| [indexedReference](HclParser/indexedReference.md)() |  |
| [interpolation](HclParser/interpolation.md)() |  |
| [list](HclParser/list.md)() |  |
| [map](HclParser/map.md)() |  |
| [mapEntry](HclParser/mapEntry.md)() |  |
| [mapKey](HclParser/mapKey.md)() |  |
| [multilineString](HclParser/multilineString.md)() |  |
| [nestedBlock](HclParser/nestedBlock.md)() |  |
| [reference](HclParser/reference.md)() |  |
| [value](HclParser/value.md)() |  |
| const [BOOL](HclParser/BOOL.md) |  |
| const [CLOSE_BRACE](HclParser/CLOSE_BRACE.md) |  |
| const [CLOSE_BRACKET](HclParser/CLOSE_BRACKET.md) |  |
| const [CLOSE_PAREN](HclParser/CLOSE_PAREN.md) |  |
| const [COMMA](HclParser/COMMA.md) |  |
| const [COMMENT](HclParser/COMMENT.md) |  |
| const [COMMENT_MULTI](HclParser/COMMENT_MULTI.md) |  |
| static readonly [DefaultVocabulary](HclParser/DefaultVocabulary.md) |  |
| const [EQUAL](HclParser/EQUAL.md) |  |
| const [IDENTIFIER](HclParser/IDENTIFIER.md) |  |
| const [NEWLINE](HclParser/NEWLINE.md) |  |
| const [NUMBER](HclParser/NUMBER.md) |  |
| const [OPEN_BRACE](HclParser/OPEN_BRACE.md) |  |
| const [OPEN_BRACKET](HclParser/OPEN_BRACKET.md) |  |
| const [OPEN_PAREN](HclParser/OPEN_PAREN.md) |  |
| const [PORT_RANGE](HclParser/PORT_RANGE.md) |  |
| static readonly [ruleNames](HclParser/ruleNames.md) |  |
| const [RULE_attribute](HclParser/RULE_attribute.md) |  |
| const [RULE_block](HclParser/RULE_block.md) |  |
| const [RULE_blockLabel](HclParser/RULE_blockLabel.md) |  |
| const [RULE_body](HclParser/RULE_body.md) |  |
| const [RULE_document](HclParser/RULE_document.md) |  |
| const [RULE_expression](HclParser/RULE_expression.md) |  |
| const [RULE_functionCall](HclParser/RULE_functionCall.md) |  |
| const [RULE_indexedAttribute](HclParser/RULE_indexedAttribute.md) |  |
| const [RULE_indexedReference](HclParser/RULE_indexedReference.md) |  |
| const [RULE_interpolation](HclParser/RULE_interpolation.md) |  |
| const [RULE_list](HclParser/RULE_list.md) |  |
| const [RULE_map](HclParser/RULE_map.md) |  |
| const [RULE_mapEntry](HclParser/RULE_mapEntry.md) |  |
| const [RULE_mapKey](HclParser/RULE_mapKey.md) |  |
| const [RULE_multilineString](HclParser/RULE_multilineString.md) |  |
| const [RULE_nestedBlock](HclParser/RULE_nestedBlock.md) |  |
| const [RULE_reference](HclParser/RULE_reference.md) |  |
| const [RULE_value](HclParser/RULE_value.md) |  |
| const [STRING](HclParser/STRING.md) |  |
| const [T__0](HclParser/T__0.md) |  |
| const [T__1](HclParser/T__1.md) |  |
| const [T__2](HclParser/T__2.md) |  |
| const [T__3](HclParser/T__3.md) |  |
| const [T__4](HclParser/T__4.md) |  |
| const [WHITESPACE](HclParser/WHITESPACE.md) |  |
| static readonly [_ATN](HclParser/_ATN.md) |  |
| class [AttributeContext](HclParser.AttributeContext.md) |  |
| class [BlockContext](HclParser.BlockContext.md) |  |
| class [BlockLabelContext](HclParser.BlockLabelContext.md) |  |
| class [BodyContext](HclParser.BodyContext.md) |  |
| class [DocumentContext](HclParser.DocumentContext.md) |  |
| class [ExpressionContext](HclParser.ExpressionContext.md) |  |
| class [FunctionCallContext](HclParser.FunctionCallContext.md) |  |
| class [IndexedAttributeContext](HclParser.IndexedAttributeContext.md) |  |
| class [IndexedReferenceContext](HclParser.IndexedReferenceContext.md) |  |
| class [InterpolationContext](HclParser.InterpolationContext.md) |  |
| class [ListContext](HclParser.ListContext.md) |  |
| class [MapContext](HclParser.MapContext.md) |  |
| class [MapEntryContext](HclParser.MapEntryContext.md) |  |
| class [MapKeyContext](HclParser.MapKeyContext.md) |  |
| class [MultilineStringContext](HclParser.MultilineStringContext.md) |  |
| class [NestedBlockContext](HclParser.NestedBlockContext.md) |  |
| class [ReferenceContext](HclParser.ReferenceContext.md) |  |
| class [ValueContext](HclParser.ValueContext.md) |  |

## Protected Members

| name | description |
| --- | --- |
| static [decisionToDFA](HclParser/decisionToDFA.md) |  |
| static [sharedContextCache](HclParser/sharedContextCache.md) |  |

## Private Members

| name | description |
| --- | --- |
| static [HclParser](HclParser/HclParser.md)() |  |
| static readonly [_LiteralNames](HclParser/_LiteralNames.md) |  |
| static [_serializedATN](HclParser/_serializedATN.md) |  |
| static readonly [_SymbolicNames](HclParser/_SymbolicNames.md) |  |

## See Also

* namespace [global](../globalNamespace.md.md)
* assembly [Hcl](../Hcl.md)

<!-- DO NOT EDIT: generated by xmldocmd for Hcl.dll -->
