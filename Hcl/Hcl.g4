grammar Hcl;

// Entry point for the HCL file, allowing any number of blocks
document: block* EOF ;

// Definition of a block (module, resource, provider, or Terraform settings)
block: IDENTIFIER STRING? STRING? OPEN_BRACE body CLOSE_BRACE ;

// The body of a block, allowing attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT)* ;

// Attribute to distinguish between simple, indexed, and map values
attribute: IDENTIFIER EQUAL value
         | IDENTIFIER EQUAL map
         | indexedAttribute EQUAL value ;

// Indexed attributes for keys like `metadata["key"]`
// indexedAttribute: IDENTIFIER OPEN_BRACKET STRING CLOSE_BRACKET ;
indexedAttribute: IDENTIFIER OPEN_BRACKET (STRING | NUMBER) CLOSE_BRACKET ;


// Nested blocks, e.g., `required_providers { ... }`
nestedBlock: IDENTIFIER OPEN_BRACE body CLOSE_BRACE ;

// Lists: Sequences of values enclosed in `[ ]`
// list: OPEN_BRACKET ((value | indexedAttribute | reference | indexedReference) (COMMA (value | indexedAttribute | reference | indexedReference))*)? CLOSE_BRACKET ;
list: OPEN_BRACKET ((value | reference | indexedAttribute | indexedReference) (COMMA (value | reference | indexedAttribute | indexedReference))*)? CLOSE_BRACKET ;

// Map: Key-value pairs enclosed in `{ }`, separated by commas or newlines
map: OPEN_BRACE (mapEntry (COMMA | NEWLINE)* )* CLOSE_BRACE ;

// Map Entry: A key-value pair
mapEntry: mapKey EQUAL value ;

// Map Key: Supports identifiers, strings, indexed attributes, and references
mapKey: STRING | IDENTIFIER | indexedAttribute | reference ;

// Values: Can be booleans, strings, numbers, lists, maps, references, interpolations, or function calls
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | reference
     | indexedReference
     | interpolation
     | functionCall ;

// Interpolations: `${expression}`
interpolation: '${' expression '}' ;

// References: `module.resource.property` or similar
// reference: IDENTIFIER ('.' IDENTIFIER | '.' indexedAttribute | '.' IDENTIFIER OPEN_BRACKET (NUMBER | STRING | '*') CLOSE_BRACKET)* ;
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
