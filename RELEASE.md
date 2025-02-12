# ModPosh.HCL Parser Version 1.0.0

This is the initial release of the HCL Parser. It uses ANTLR to parse the HCL structure into .net objects. Ideally, you should be able to leverage this in your own applications and use it in conjunction with PowerShell.

## BUG

* issue-23: Correct json/hcl conversion
* issue-20: Update validator/parser to handle EOT
* issue-18: fix regression issue, extraneous dots in reference
* issue-17: fix regression issue for port_range with numbers
* issue-15: fix regression issue in client parsing, provider blocks
* issue-13: fix backend block issue in backend terraform files
* issue-12: fix null object in variable
* issue-11: fix asterisk issue
* issue-10: fix port_range issue
* issue-9: Fixed extra dot's in reference notation

## DOCUMENTATION

* issue-16: Add detailed error messaging
* issue-14: Update code documentation

## ENHANCEMENT

* issue-24: Update to .net 8.0
* issue-22: Overhaul converter code
* issue-21: Add classes to strongly type return objects
* issue-19: Add converter for json/hcl
* issue-8: Create Validator/Parser for complex resource
* issue-7: Create Validator/Parser for provider.tf
* issue-6: Create Validator/Parser for complex module resources
* issue-5: Create Validator/Parser for mixed resource data files
* issue-4: Create Validator/Parser for mixed module and resource files
* issue-3: Create Validator/Parser for resource files
* issue-2: Create Validator/Parser for module files
* issue-1: Create ANTLR Grammar File

