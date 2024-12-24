grammar Hcl;

// Entry point of the grammar, allowing multiple blocks in a document
document: block* EOF;

// A block represents resources or modules, e.g., `resource "type" "name" { body }`
block: IDENTIFIER STRING (STRING)? '{' body '}';

// The body of a block contains attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT)*;

// Attributes are key-value pairs defined with the syntax `key = value`
attribute: IDENTIFIER '=' value;

// Nested blocks, e.g., `cluster { ... }`
nestedBlock: IDENTIFIER '{' body '}';

// Values can be booleans, strings, numbers, lists, maps, interpolations, or references
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | interpolation
     | reference;

// Lists are sequences of values enclosed in `[ ]`
list: '[' (value (',' value)*)? ']';

// Maps are key-value pairs enclosed in `{ }`
map: '{' (mapEntry (',' mapEntry)*)? '}';
mapEntry: IDENTIFIER '=' value;

// Interpolations like `${var.name}`
interpolation: '${' IDENTIFIER ('.' IDENTIFIER)* '}';

// References like `google_bigtable_instance.xyz-big-table.name`
reference: IDENTIFIER ('.' IDENTIFIER)+;

// Tokens

// Boolean values, defined as `true` or `false`
BOOL: 'true' | 'false';

// Strings enclosed in double quotes
STRING: '"' (~["\\] | '\\' .)* '"';

// Numbers, including integers and floating-point values
NUMBER: [0-9]+ ('.' [0-9]+)?;

// Identifiers for keys, variables, and resource types
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]*;

// Comments start with `#` and run to the end of the line
COMMENT: '#' ~[\r\n]* -> skip;

// Skip whitespace characters
WHITESPACE: [ \t\r\n]+ -> skip;
