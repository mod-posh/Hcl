grammar Hcl;

// Entry point for the HCL file, allowing any number of blocks
document: block* EOF ;

// Definition of a block (module, resource, or data block)
block: IDENTIFIER STRING STRING? OPEN_BRACE body CLOSE_BRACE ;

// The body of a block, allowing attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT)* ;

// Updated attribute to distinguish between simple, indexed, and map values
attribute: IDENTIFIER EQUAL value
         | IDENTIFIER EQUAL map
         | indexedAttribute EQUAL value ;

// Indexed attributes for keys like `metadata["key"]`
indexedAttribute: IDENTIFIER OPEN_BRACKET STRING CLOSE_BRACKET ;

// Nested blocks, e.g., `managed { ... }`
nestedBlock: IDENTIFIER OPEN_BRACE body CLOSE_BRACE ;

// Lists: Sequences of values enclosed in `[ ]`
list: OPEN_BRACKET (value | indexedAttribute) (COMMA (value | indexedAttribute))* CLOSE_BRACKET ;

// Map: Key-value pairs enclosed in `{ }`, separated by commas or newlines
map: OPEN_BRACE (mapEntry (COMMA | NEWLINE)* mapEntry?)* CLOSE_BRACE;

// Map Entry: A key-value pair
mapEntry: mapKey EQUAL value ;

// Map Key: Supports identifiers, strings, and indexed attributes
mapKey: STRING | IDENTIFIER | indexedAttribute ;

// Values: Can be booleans, strings, numbers, lists, maps, references, interpolations, or function calls
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | reference
     | interpolation
     | functionCall ;

// Interpolations: `${expression}`
interpolation: '${' expression '}' ;

// References: `module.resource.property` or similar
reference: IDENTIFIER ('.' IDENTIFIER)* ;

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

// Identifiers (used for keys, resource types, etc.)
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]* ;

// Comments (`# ...`)
COMMENT: '#' ~[\r\n]* -> skip ;

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
