using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Data : HclBlock
    {
        public override string ToHcl()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Type) || string.IsNullOrWhiteSpace(Name))
                throw new InvalidOperationException("Data block must have a Type and Name.");

            sb.AppendLine($"data \"{Type}\" \"{Name}\" {{");

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
            return $"{{ \"type\": \"{Type}\", \"name\": \"{Name}\", \"body\": {{ {string.Join(", ", keyValuePairs)} }} }}";
        }
    }
}
