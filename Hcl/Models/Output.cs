using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Output : HclBlock
    {
        public HclValue? Value { get; set; }

        public override string ToHcl()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new InvalidOperationException("Output block must have a Name.");

            var sb = new StringBuilder();
            sb.AppendLine($"output \"{Name}\" {{");

            if (Value != null)
                sb.AppendLine($"  value = {Value.ToHcl()}");

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToJson()
        {
            return $"{{ \"name\": \"{Name}\", \"value\": {Value?.ToJson() ?? "null"} }}";
        }
    }
}
