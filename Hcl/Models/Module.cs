using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModPosh.Hcl.Models
{
    public class Module : HclBlock
    {
        public Dictionary<string, object?> Attributes { get; set; } = new();

        public override string ToHcl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"module \"{Name}\" {{");

            foreach (var kvp in Body)
            {
                if (kvp.Value.Type == HclValueType.Map || kvp.Value.Type == HclValueType.List)
                {
                    sb.AppendLine($"  {kvp.Key} {kvp.Value.ToHcl()}");
                }
                else
                {
                    sb.AppendLine($"  {kvp.Key} = {kvp.Value.ToHcl()}");
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToJson()
        {
            // Create a dictionary representing the module for JSON serialization
            var jsonObject = new Dictionary<string, object?>
            {
                { "type", "module" },
                { "name", Name }
            };

            // Add the module body attributes dynamically
            foreach (var kvp in Body)
            {
                jsonObject[kvp.Key] = kvp.Value.Value; // Use the raw value for JSON serialization
            }

            // Serialize the dictionary to JSON using System.Text.Json
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Pretty-print the JSON
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull // Ignore null values
            };

            return JsonSerializer.Serialize(jsonObject, options);
        }
    }
}
