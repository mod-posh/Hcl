# HCL Parser

## Overview
The **HCL Parser** is a custom-built C# library designed to parse, manipulate, and generate HashiCorp Configuration Language (HCL) files. This parser plays a crucial role in the Terraform module update process by allowing structured modifications to `variables.tf`, `main.tf`, and other HCL files. The library provides an object-oriented representation of HCL, enabling easy transformations and validation before updating Terraform modules.

## Features
- **HCL Parsing:** Converts HCL into structured objects that can be programmatically modified.
- **Object-Oriented Representation:** Defines HCL elements as discrete C# objects with overridable methods.
- **HCL Generation:** Converts modified objects back into valid HCL strings.
- **PowerShell Compatibility:** Can be integrated into a PowerShell module for automation in CI/CD pipelines.

## Installation
The HCL Parser can be added to a .NET project via NuGet:

```sh
dotnet add package ModPosh.HclParser
```

Alternatively, if using an internal feed:

```sh
dotnet nuget add source <internal_feed_url>
dotnet add package ModPosh.HclParser --source <internal_feed>
```

## Usage

### Parsing HCL
```csharp
using ModPosh.HclParser;

string hclText = @"variable \"instance_count\" {\n  type = number\n  default = 1\n}";

HclDocument doc = HclParser.Parse(hclText);
foreach (var variable in doc.Variables)
{
    Console.WriteLine($"Variable: {variable.Name}, Default: {variable.Default}");
}
```

### Modifying HCL
```csharp
HclVariable variable = new HclVariable("instance_type")
{
    Type = "string",
    Default = "n1-standard-1"
};

HclDocument doc = new HclDocument();
doc.Add(variable);

string outputHcl = doc.ToString();
Console.WriteLine(outputHcl);
```


## Future Enhancements
- Support for HCL2 with nested blocks and expressions.
- Integration with Azure DevOps for automated module updates.
- Additional validation rules to detect deprecated or incorrect configurations.

## Contributing
Contributions are welcome! Please follow the [contribution guidelines](CONTRIBUTING.md) and submit a pull request.

## License
This project is licensed under the MIT License.

