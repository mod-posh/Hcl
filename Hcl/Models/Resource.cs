using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Resource : HclBlock
    {
        public override string ToHcl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"resource \"{Type}\" \"{Name}\" {{");

            foreach (var kvp in Body)
            {
                if (kvp.Value.Type == HclValueType.Map || kvp.Value.Type == HclValueType.List)
                {
                    sb.AppendLine($"  {kvp.Key} {{");
                    sb.AppendLine(kvp.Value.ToHcl());
                    sb.AppendLine("  }");
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
            var jsonObject = new Dictionary<string, object?>
    {
        { "type", "resource" },
        { "resource_type", Type },
        { "name", Name }
    };

            foreach (var kvp in Body)
            {
                jsonObject[kvp.Key] = kvp.Value.ToJson();
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            return JsonSerializer.Serialize(jsonObject, options);
        }
    }
}
