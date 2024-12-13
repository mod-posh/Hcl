grammar Hcl;

// Entry point
document: block* EOF;

// General block structure: `type "name" "optionalLabel" { ... }`
block: IDENTIFIER STRING (STRING)? '{' body '}';

// Body of a block
body: (attribute | block)*;

// Attributes like `key = value`
attribute: IDENTIFIER '=' value;

// Supported values
value: STRING
     | NUMBER
     | BOOL
     | list
     | map
     | complexBlock
     | interpolation;

// Lists like `[value, value]`
list: '[' value (',' value)* ']';

// Maps like `{ key = value, key = value }`
map: '{' mapEntry (',' mapEntry)* '}';
mapEntry: IDENTIFIER '=' value;

// Complex blocks like `default = { resources = ["secrets"] }`
complexBlock: '{' (attribute | mapEntry)* '}';

// Interpolations like `${var.name}`
interpolation: '${' IDENTIFIER ('.' IDENTIFIER)* '}';

// Tokens
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;
STRING: '"' .*? '"';
NUMBER: [0-9]+ ('.' [0-9]+)?;
BOOL: 'true' | 'false';
WHITESPACE: [ \t\r\n]+ -> skip;
COMMENT: '#' ~[\r\n]* -> skip;
