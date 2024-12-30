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
    }
    public class Provider : HclBlock { }
    public class Resource : HclBlock { }
    public class Variable : HclBlock { }
    public class Module : HclBlock { }
    public class Data : HclBlock { }
    public class Terraform : HclBlock
    {
        public List<Backend> Backends { get; set; } = new();
    }
    public class Backend
    {
        public string Type { get; set; } = string.Empty;
        public Dictionary<string, HclValue>? Body { get; set; }
    }
    public class Output : HclBlock
    {
        public HclValue? Value { get; set; }
    }
}
