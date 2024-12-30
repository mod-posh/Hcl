using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

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
                sb.AppendLine($"  {kvp.Key} = {kvp.Value.ToHcl()}");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToJson()
        {
            var keyValuePairs = Body.Select(kvp => $"\"{kvp.Key}\": {kvp.Value.ToJson()}");
            return $"{{ \"type\": \"module\", \"name\": \"{Name}\", {string.Join(", ", keyValuePairs)} }}";
        }
    }
}
