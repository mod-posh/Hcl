using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Provider : HclBlock
    {
        public override string ToHcl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"provider \"{Type}\" {{");

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
            return $"{{ \"type\": \"{Type}\", \"body\": {{ {string.Join(", ", keyValuePairs)} }} }}";
        }
    }
}
