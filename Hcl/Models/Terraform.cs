using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Terraform : HclBlock
    {
        public List<Backend> Backends { get; set; } = new();
    }
    public class Backend
    {
        public string Type { get; set; } = string.Empty;
        public Dictionary<string, HclValue>? Body { get; set; }
    }
}
