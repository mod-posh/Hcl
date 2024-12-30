using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ModPosh.Hcl.Models
{
    public class HclDocument
    {
        public List<Provider> Providers { get; set; } = new();
        public List<Resource> Resources { get; set; } = new();
        public List<Variable> Variables { get; set; } = new();
        public List<Module> Modules { get; set; } = new();
        public List<Data> DataBlocks { get; set; } = new();
        public List<Terraform> TerraformBlocks { get; set; } = new(); // Added
        public List<Output> Outputs { get; set; } = new(); // Added
    }
}
