using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class HclValue
    {
        public HclValueType Type { get; set; }
        public object? Value { get; set; }

        public string ToHcl()
        {
            return Type switch
            {
                HclValueType.String => $"\"{Value}\"",
                HclValueType.Number => Value?.ToString() ?? "0",
                HclValueType.Boolean => Value?.ToString()?.ToLower() ?? "false",
                HclValueType.List => Value is List<HclValue> list && list.Any()
                    ? $"[{string.Join(", ", list.Select(v => v.ToHcl()))}]"
                    : "[]", // Empty array
                HclValueType.Map => Value is Dictionary<string, HclValue> map && map.Any()
                    ? $"{{\n{string.Join("\n", map.Select(kv => $"  {kv.Key} = {kv.Value.ToHcl()}"))}\n}}"
                    : "{ }", // Empty map
                _ => "null" // Handle null or unknown types
            };
        }

        public string ToJson()
        {
            return Type switch
            {
                HclValueType.String => $"\"{Value}\"",
                HclValueType.Number => Value?.ToString() ?? "0",
                HclValueType.Boolean => Value?.ToString()?.ToLower() ?? "false",
                HclValueType.List => Value is List<HclValue> list
                    ? $"[{string.Join(", ", list.Select(v => v.ToJson()))}]"
                    : "[]", // Empty array
                HclValueType.Map => Value is Dictionary<string, HclValue> map
                    ? $"{{ {string.Join(", ", map.Select(kv => $"\"{kv.Key}\": {kv.Value.ToJson()}"))} }}"
                    : "{ }", // Empty map
                _ => "null" // Handle null or unknown types
            };
        }
    }
    public enum HclValueType
    {
        String,
        Number,
        Boolean,
        List,
        Map,
        Reference,
        FunctionCall,
        Bool, // Add this
        Null,
        Unknown // Add this
    }
}
