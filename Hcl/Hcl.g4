grammar Hcl;

// Entry point for the HCL file, which can contain multiple blocks
document: block* EOF ;

// Definition of a block, which is the fundamental structure in HCL
block: IDENTIFIER blockLabel? OPEN_BRACE body CLOSE_BRACE ;

// Block label: Defines optional labels for blocks (e.g., `backend "azurerm"`)
blockLabel: STRING+ ;

// The body of a block, which can include attributes, nested blocks, comments, or newlines
body: (attribute | nestedBlock | COMMENT | NEWLINE)* ;

// Attributes: Define key-value pairs or assignments (e.g., `key = value`)
attribute: IDENTIFIER EQUAL value ;

// Nested blocks: Define nested structures within a block (e.g., `provider { ... }`)
nestedBlock: IDENTIFIER blockLabel? OPEN_BRACE body CLOSE_BRACE ;

// Indexed attributes: Define indexed keys like `metadata["key"]`
indexedAttribute: IDENTIFIER OPEN_BRACKET (STRING | NUMBER) CLOSE_BRACKET ;

// Lists: Define sequences of values enclosed in square brackets (e.g., `[1, 2, 3]`)
list: OPEN_BRACKET ((value | indexedAttribute | reference | indexedReference) (COMMA (value | indexedAttribute | reference | indexedReference))*)? CLOSE_BRACKET ;

// Map: Define key-value pairs enclosed in curly braces (e.g., `{ key = value }`)
map: OPEN_BRACE (mapEntry (COMMA | NEWLINE)* )* CLOSE_BRACE ;

// Map Entry: Represents a single key-value pair in a map
mapEntry: mapKey EQUAL value ;

// Map Key: Keys in a map, which can be strings, identifiers, or references
mapKey: STRING | IDENTIFIER | indexedAttribute | reference ;

// Values: The possible types of values in HCL (e.g., booleans, strings, lists, maps)
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | reference
     | indexedReference
     | interpolation
     | functionCall ;

// Interpolations: Expressions enclosed in `${}` (e.g., `${var.value}`)
interpolation: '${' expression '}' ;

// References: Allow dot notation for accessing properties (e.g., `module.resource.property`)
reference: IDENTIFIER ('.' IDENTIFIER | '.' '*' | '.' IDENTIFIER OPEN_BRACKET (STRING | NUMBER) CLOSE_BRACKET)* ;

// Indexed References: Allow accessing elements with a key or index (e.g., `resource["key"]`)
indexedReference: IDENTIFIER OPEN_BRACKET (STRING | NUMBER | '*') CLOSE_BRACKET ('.' IDENTIFIER)* ;

// Function Calls: Allow invoking functions with arguments (e.g., `function(arg1, arg2)`)
functionCall: IDENTIFIER OPEN_PAREN (value (',' value)*)? CLOSE_PAREN ;

// Expressions within interpolations: Can be references, function calls, or values
expression: reference
          | functionCall
          | value ;

// Tokens

// Boolean values (`true` or `false`)
BOOL: 'true' | 'false' ;

// Strings: Support special characters and escape sequences (e.g., `"string"`)
STRING: '"' (~["\\] | '\\' .)* '"' ;

// Numbers: Integers or floats (e.g., `123`, `45.67`)
NUMBER: [0-9]+ ('.' [0-9]+)? ;

// Identifiers: Used for keys, resource types, etc. (e.g., `my_variable`)
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]* ;

// Comments: Lines starting with `#`
COMMENT: '#' ~[\r\n]* -> skip ;

// Skip whitespace
WHITESPACE: [ \t\r\n]+ -> skip ;

// Symbols
EQUAL: '=' ;          // Equal sign for assignments
OPEN_BRACE: '{' ;     // Open curly brace for block bodies or maps
CLOSE_BRACE: '}' ;    // Close curly brace
OPEN_BRACKET: '[' ;   // Open square bracket for lists or indexed attributes
CLOSE_BRACKET: ']' ;  // Close square bracket
OPEN_PAREN: '(' ;     // Open parenthesis for function calls
CLOSE_PAREN: ')' ;    // Close parenthesis
COMMA: ',' ;          // Comma for separating list or map elements
NEWLINE: [\r\n]+ -> skip ; // Skip newlines
