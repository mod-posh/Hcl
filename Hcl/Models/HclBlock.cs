using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public abstract class HclBlock
    {
        public string Type { get; set; } = string.Empty;
        public string? Name { get; set; }
        public Dictionary<string, HclValue> Body { get; set; } = new();

        public abstract string ToHcl();
        public abstract string ToJson();
    }
}
