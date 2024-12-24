grammar Hcl;

// Entry point for the HCL file, allowing any number of blocks (modules, resources, etc.)
document: block* EOF;

// Definition of a block (module, resource, etc.)
block: IDENTIFIER STRING (STRING)? '{' body '}';

// The body of a block, allowing attributes, nested blocks, or comments
body: (attribute | nestedBlock | COMMENT)*;

// Attributes are key-value pairs like `key = value`
attribute: IDENTIFIER '=' value;

// Nested blocks, e.g., `cluster_config { ... }`
nestedBlock: IDENTIFIER '{' body '}';

// Values: Can be booleans, strings, numbers, lists, maps, references, or interpolations
value: BOOL
     | STRING
     | NUMBER
     | list
     | map
     | reference
     | interpolation;

// Lists: Sequences of values enclosed in `[ ]`
list: '[' (value (',' value)*)? ']';

// Maps: Key-value pairs enclosed in `{ }`
map: '{' (mapEntry (',' mapEntry)*)? '}';
mapEntry: (IDENTIFIER | STRING) '=' value; // Allow both IDENTIFIER and STRING as map keys

// Interpolations: `${var.name}`
interpolation: '${' IDENTIFIER ('.' IDENTIFIER)* '}';

// References: `module.resource.property`
reference: IDENTIFIER ('.' IDENTIFIER)+;

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
