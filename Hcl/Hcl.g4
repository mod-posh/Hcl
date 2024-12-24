grammar Hcl;

// Entry point of the grammar, a document can contain multiple blocks and must end with EOF
document: block* EOF;

// Definition of a block, e.g., `module "name" { body }`
// A block starts with an identifier, followed by a string (name), and has a body enclosed in `{ }`
block: IDENTIFIER STRING '{' body '}';

// The body of a block contains a sequence of attributes or comments
body: (attribute | COMMENT)*;

// Attributes are key-value pairs defined with the syntax `key = value`
attribute: IDENTIFIER '=' value;

// A value can be one of several types: boolean, string, number, list, map, or interpolation
value: BOOL                // Explicitly handle booleans like `true` or `false`
     | STRING              // Strings enclosed in double quotes
     | NUMBER              // Numbers, including integers and floats
     | list                // Lists of values enclosed in square brackets `[ ]`
     | map                 // Maps (dictionaries) with key-value pairs enclosed in `{ }`
     | interpolation;      // Interpolations, e.g., `${var.name}`

// Lists are defined as sequences of values enclosed in `[ ]`
// Lists can be empty or contain multiple values separated by commas
list: '[' (value (',' value)*)? ']';

// Maps are key-value pairs enclosed in `{ }`
// Maps can be empty or contain multiple key-value pairs separated by commas
map: '{' (mapEntry (',' mapEntry)*)? '}';

// A map entry is a key-value pair, where the key is an identifier and the value can be any valid value
mapEntry: IDENTIFIER '=' value;

// Interpolations are expressions enclosed in `${ }`, used to dynamically reference variables or values
// Supports dot notation for accessing nested identifiers
interpolation: '${' IDENTIFIER ('.' IDENTIFIER)* '}';

// Token definitions for specific types

// Boolean values, defined as `true` or `false`
BOOL: 'true' | 'false';

// Strings enclosed in double quotes
// Supports escaped characters within the string
STRING: '"' (~["\\] | '\\' .)* '"';

// Numbers, including integers and floating-point values
NUMBER: [0-9]+ ('.' [0-9]+)?;

// Identifiers, used for keys, variable names, etc.
// Must start with a letter or underscore and can include alphanumeric characters or hyphens
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]*;

// Comments start with `#` and run to the end of the line
COMMENT: '#' ~[\r\n]* -> skip;

// Skip whitespaces like spaces, tabs, and newlines
WHITESPACE: [ \t\r\n]+ -> skip;
