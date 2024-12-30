using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ModPosh.Hcl.Utilities
{
    /// <summary>
    /// Provides methods to convert between HCL and JSON formats.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts HCL input to JSON format.
        /// </summary>
        /// <param name="hclInput">The HCL input string.</param>
        /// <returns>A JSON-formatted string representation of the HCL input.</returns>
        public static string ToJson(object parsedObject)
        {
            try
            {
                if (parsedObject == null)
                {
                    throw new ArgumentNullException(nameof(parsedObject), "Parsed object cannot be null.");
                }

                // Serialize the parsed HCL structure to JSON
                return JsonSerializer.Serialize(parsedObject, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting HCL to JSON.", ex);
            }
        }

        /// <summary>
        /// Converts a JSON representation of HCL back into HCL format.
        /// </summary>
        /// <param name="jsonInput">The JSON string representation of the HCL configuration.</param>
        /// <returns>A string containing the HCL configuration.</returns>
        public static string ToHcl(string jsonInput)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize the JSON input
                var resources = JsonSerializer.Deserialize<JsonElement>(jsonInput, options);
                if (resources.ValueKind != JsonValueKind.Array)
                {
                    throw new Exception("Expected JSON array of HCL resources.");
                }

                // Convert JSON to HCL
                return ConvertJsonToHcl(resources);
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting JSON to HCL.", ex);
            }
        }

        private static string ConvertJsonToHcl(JsonElement jsonElement)
        {
            var hclBuilder = new StringBuilder();

            foreach (var resource in jsonElement.EnumerateArray())
            {
                var type = resource.GetProperty("type").GetString();
                var name = resource.GetProperty("name").GetString();
                var optionalLabel = resource.TryGetProperty("optionalLabel", out var label) && !string.IsNullOrEmpty(label.GetString())
                    ? label.GetString()
                    : null;
                var body = resource.GetProperty("body");

                // Resource Declaration
                hclBuilder.Append($"{type} \"{name}\"");
                if (!string.IsNullOrEmpty(optionalLabel))
                {
                    hclBuilder.Append($" \"{optionalLabel}\"");
                }
                hclBuilder.AppendLine(" {");

                // Convert Body
                hclBuilder.Append(ConvertBodyToHcl(body, 2));

                hclBuilder.AppendLine("}");
            }

            return hclBuilder.ToString();
        }

        private static string ConvertBodyToHcl(JsonElement body, int indentLevel)
        {
            var hclBuilder = new StringBuilder();
            var indent = new string(' ', indentLevel);

            foreach (var property in body.EnumerateObject())
            {
                var key = property.Name;
                var value = property.Value;

                switch (value.ValueKind)
                {
                    case JsonValueKind.Object:
                        hclBuilder.AppendLine($"{indent}{key} {{");
                        hclBuilder.Append(ConvertBodyToHcl(value, indentLevel + 2));
                        hclBuilder.AppendLine($"{indent}}}");
                        break;

                    case JsonValueKind.Array:
                        hclBuilder.AppendLine($"{indent}{key} = [");
                        foreach (var item in value.EnumerateArray())
                        {
                            if (item.ValueKind != JsonValueKind.Null)
                            {
                                hclBuilder.AppendLine($"{indent}  {ConvertValueToHcl(item)},");
                            }
                        }
                        hclBuilder.AppendLine($"{indent}]");
                        break;

                    default:
                        hclBuilder.AppendLine($"{indent}{key} = {ConvertValueToHcl(value)}");
                        break;
                }
            }

            return hclBuilder.ToString();
        }

        private static string ConvertValueToHcl(JsonElement value)
        {
            return value.ValueKind switch
            {
                JsonValueKind.String => $"\"{value.GetString()}\"",
                JsonValueKind.Number => value.GetRawText(),
                JsonValueKind.True => "true",
                JsonValueKind.False => "false",
                JsonValueKind.Null => "null",
                _ => throw new Exception($"Unhandled value kind: {value.ValueKind}")
            };
        }
    }
}
