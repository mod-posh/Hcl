grammar Hcl;

// Entry point for the HCL file
document: block* EOF ;

// Definition of a block
block: IDENTIFIER blockLabel? OPEN_BRACE body CLOSE_BRACE ;

// Block label: Supports optional strings (e.g., `backend "azurerm"`)
blockLabel: STRING+ ;

// The body of a block, allowing attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT | COMMENT_MULTI | NEWLINE)* ;

// Attributes for key-value pairs
attribute: IDENTIFIER EQUAL value ;

// Nested blocks (e.g., `required_providers { ... }`)
nestedBlock: IDENTIFIER blockLabel? OPEN_BRACE body CLOSE_BRACE ;

// Indexed attributes for keys like `metadata["key"]`
indexedAttribute: IDENTIFIER OPEN_BRACKET (STRING | NUMBER) CLOSE_BRACKET ;

// Lists: Sequences of values enclosed in `[ ]`
list: OPEN_BRACKET ((value | indexedAttribute | reference | indexedReference | PORT_RANGE) (COMMA (value | indexedAttribute | reference | indexedReference | PORT_RANGE))*)? CLOSE_BRACKET ;

// Map: Key-value pairs enclosed in `{ }`, separated by commas or newlines
map: OPEN_BRACE (mapEntry (COMMA | NEWLINE)* )* CLOSE_BRACE ;

// Map Entry: A key-value pair
mapEntry: mapKey EQUAL value ;

// Map Key: Supports identifiers, strings, indexed attributes, and references
mapKey: STRING | IDENTIFIER | indexedAttribute | reference ;

multilineString: '<<-' IDENTIFIER NEWLINE (~NEWLINE)* NEWLINE IDENTIFIER NEWLINE? ;

// Values: Can be booleans, strings, numbers, lists, maps, references, interpolations, or function calls
value: BOOL
     | STRING
     | multilineString
     | NUMBER
     | PORT_RANGE
     | list
     | map
     | reference
     | indexedReference
     | interpolation
     | functionCall
     | 'null' ;

// Interpolations: `${expression}`
interpolation: '${' expression '}' ;

// References: `module.resource.property` or similar
reference: IDENTIFIER ('.' IDENTIFIER | '.' '*' | '.' IDENTIFIER OPEN_BRACKET (STRING | NUMBER) CLOSE_BRACKET)* ;

// Indexed references: `resource["key"]`
indexedReference: IDENTIFIER OPEN_BRACKET (STRING | NUMBER | '*') CLOSE_BRACKET ('.' IDENTIFIER)* ;

// Function calls: `function(args...)`
functionCall: IDENTIFIER OPEN_PAREN (value (',' value)*)? CLOSE_PAREN ;

// Expressions within interpolations
expression: reference
          | functionCall
          | value ;

// Tokens

// Boolean values (`true` or `false`)
BOOL: 'true' | 'false' ;

// Strings, supporting special characters and escape sequences
STRING: '"' (~["\\] | '\\' .)* '"' ;

// Numbers (integers or floats)
NUMBER: [0-9]+ ('.' [0-9]+)? ;

// Port range: A number followed by a '-' and another number (e.g., `443-445`)
PORT_RANGE: [0-9]+ '-' [0-9]+ ;

// Identifiers (used for keys, resource types, etc.)
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]* ;

// Comments (`# ...` and `/* ... */`)
COMMENT: '#' ~[\r\n]* -> skip ;
COMMENT_MULTI: '/*' .*? '*/' -> skip ;

// Skip whitespace
WHITESPACE: [ \t\r\n]+ -> skip ;

// Symbols
EQUAL: '=' ;
OPEN_BRACE: '{' ;
CLOSE_BRACE: '}' ;
OPEN_BRACKET: '[' ;
CLOSE_BRACKET: ']' ;
OPEN_PAREN: '(' ;
CLOSE_PAREN: ')' ;
COMMA: ',' ;
NEWLINE: [\r\n]+ -> skip ;

// Add support for interpolations in expressions
fragment DOLLAR: '$' ;
fragment CURLY_OPEN: '{' ;
fragment CURLY_CLOSE: '}' ;
