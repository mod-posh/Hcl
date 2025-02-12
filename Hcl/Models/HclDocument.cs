using ModPosh.Hcl.Models;

namespace ModPosh.Hcl.Models
{
    public class HclDocument
    {
        public List<Provider> Providers { get; set; }
        public List<Resource> Resources { get; set; }
        public List<Variable> Variables { get; set; }
        public List<Module> Modules { get; set; }
        public List<Data> DataBlocks { get; set; }
        public List<Terraform> TerraformBlocks { get; set; }
        public List<Output> Outputs { get; set; }

        public HclDocument()
        {
            Providers = new List<Provider>();
            Resources = new List<Resource>();
            Variables = new List<Variable>();
            Modules = new List<Module>();
            DataBlocks = new List<Data>();
            TerraformBlocks = new List<Terraform>();
            Outputs = new List<Output>();
        }
        public string ToHcl()
        {
            var sections = new List<string>();

            if (Providers.Count > 0) sections.Add(string.Join("\n\n", Providers.Select(p => p.ToHcl())));
            if (Resources.Count > 0) sections.Add(string.Join("\n\n", Resources.Select(r => r.ToHcl())));
            if (Variables.Count > 0) sections.Add(string.Join("\n\n", Variables.Select(v => v.ToHcl())));
            if (Modules.Count > 0) sections.Add(string.Join("\n\n", Modules.Select(m => m.ToHcl())));
            if (DataBlocks.Count > 0) sections.Add(string.Join("\n\n", DataBlocks.Select(d => d.ToHcl())));
            if (TerraformBlocks.Count > 0) sections.Add(string.Join("\n\n", TerraformBlocks.Select(t => t.ToHcl())));
            if (Outputs.Count > 0) sections.Add(string.Join("\n\n", Outputs.Select(o => o.ToHcl())));

            return string.Join("\n\n", sections);
        }
        public string ToJson()
        {
            var keyValuePairs = new List<string>();

            if (Providers.Count > 0) keyValuePairs.Add($"\"providers\": [{string.Join(", ", Providers.Select(p => p.ToJson()))}]");
            if (Resources.Count > 0) keyValuePairs.Add($"\"resources\": [{string.Join(", ", Resources.Select(r => r.ToJson()))}]");
            if (Variables.Count > 0) keyValuePairs.Add($"\"variables\": [{string.Join(", ", Variables.Select(v => v.ToJson()))}]");
            if (Modules.Count > 0) keyValuePairs.Add($"\"modules\": [{string.Join(", ", Modules.Select(m => m.ToJson()))}]");
            if (DataBlocks.Count > 0) keyValuePairs.Add($"\"data_blocks\": [{string.Join(", ", DataBlocks.Select(d => d.ToJson()))}]");
            if (TerraformBlocks.Count > 0) keyValuePairs.Add($"\"terraform_blocks\": [{string.Join(", ", TerraformBlocks.Select(t => t.ToJson()))}]");
            if (Outputs.Count > 0) keyValuePairs.Add($"\"outputs\": [{string.Join(", ", Outputs.Select(o => o.ToJson()))}]");

            return $"{{ {string.Join(", ", keyValuePairs)} }}";
        }
    }
}