grammar Hcl;

// Entry point for the HCL file, allowing any number of blocks
document: block* EOF;

// Definition of a block (module, resource, or data block)
block: IDENTIFIER STRING STRING? '{' body '}';

// The body of a block, allowing attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT)*;

// Attributes are key-value pairs like `key = value`
attribute: IDENTIFIER '=' value;

// Nested blocks, e.g., `managed { ... }`
nestedBlock: IDENTIFIER '{' body '}';

// Values: Can be booleans, strings, numbers, lists, maps, references, interpolations, or function calls
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | reference
     | interpolation
     | functionCall;

// Lists: Sequences of values enclosed in `[ ]`
list: '[' (value (',' value)*)? ']';

// Maps: Key-value pairs enclosed in `{ }`
map: '{' (mapEntry (',' mapEntry)*)? '}';
mapEntry: (STRING | IDENTIFIER) '=' value;

// Interpolations: `${expression}`
interpolation: '${' expression '}';

// References: `module.resource.property` or similar
reference: IDENTIFIER ('.' IDENTIFIER)*;

// Function calls: `function(args...)`
functionCall: IDENTIFIER '(' (value (',' value)*)? ')';

// Expressions within interpolations
expression: reference
          | functionCall
          | value;

// Tokens

// Boolean values (`true` or `false`)
BOOL: 'true' | 'false';

// Strings, supporting special characters and escape sequences
STRING: '"' (~["\\] | '\\' .)* '"';

// Numbers (integers or floats)
NUMBER: [0-9]+ ('.' [0-9]+)?;

// Identifiers (used for keys, resource types, etc.)
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_-]*;

// Comments (`# ...`)
COMMENT: '#' ~[\r\n]* -> skip;

// Skip whitespace
WHITESPACE: [ \t\r\n]+ -> skip;
