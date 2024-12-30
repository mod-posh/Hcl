using ModPosh.Hcl.Models;

public class HclDocument
{
    public List<Provider> Providers { get; set; } = new();
    public List<Resource> Resources { get; set; } = new();
    public List<Variable> Variables { get; set; } = new();
    public List<Module> Modules { get; set; } = new();
    public List<Data> DataBlocks { get; set; } = new();
    public List<Terraform> TerraformBlocks { get; set; } = new();
    public List<Output> Outputs { get; set; } = new();

    public string ToHcl()
    {
        var sections = new List<string>
        {
            string.Join("\n\n", Providers.Select(p => p.ToHcl())),
            string.Join("\n\n", Resources.Select(r => r.ToHcl())),
            string.Join("\n\n", Variables.Select(v => v.ToHcl())),
            string.Join("\n\n", Modules.Select(m => m.ToHcl())),
            string.Join("\n\n", DataBlocks.Select(d => d.ToHcl())),
            string.Join("\n\n", TerraformBlocks.Select(t => t.ToHcl())),
            string.Join("\n\n", Outputs.Select(o => o.ToHcl()))
        };

        return string.Join("\n\n", sections.Where(s => !string.IsNullOrWhiteSpace(s)));
    }

    public string ToJson()
    {
        var keyValuePairs = new List<string>
        {
            $"\"providers\": [{string.Join(", ", Providers.Select(p => p.ToJson()))}]",
            $"\"resources\": [{string.Join(", ", Resources.Select(r => r.ToJson()))}]",
            $"\"variables\": [{string.Join(", ", Variables.Select(v => v.ToJson()))}]",
            $"\"modules\": [{string.Join(", ", Modules.Select(m => m.ToJson()))}]",
            $"\"data_blocks\": [{string.Join(", ", DataBlocks.Select(d => d.ToJson()))}]",
            $"\"terraform_blocks\": [{string.Join(", ", TerraformBlocks.Select(t => t.ToJson()))}]",
            $"\"outputs\": [{string.Join(", ", Outputs.Select(o => o.ToJson()))}]"
        };

        return $"{{ {string.Join(", ", keyValuePairs)} }}";
    }
}
