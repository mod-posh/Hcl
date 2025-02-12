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

        public Terraform()
        {
            Body = new Dictionary<string, HclValue>();  // Ensure it's initialized
            Backends = new List<Backend>();
        }

        public override string ToHcl()
        {
            var sb = new StringBuilder();
            sb.AppendLine("terraform {");

            // Add top-level Terraform configurations
            foreach (var kvp in Body)
            {
                if (kvp.Key == "required_providers" && kvp.Value.Type == HclValueType.Map)
                {
                    sb.AppendLine("  required_providers {");

                    if (kvp.Value.Value is Dictionary<string, HclValue> providerBlock)
                    {
                        foreach (var provider in providerBlock)
                        {
                            sb.AppendLine($"    {provider.Key} = {{");
                            if (provider.Value.Type == HclValueType.Map && provider.Value.Value is Dictionary<string, HclValue> providerValues)
                            {
                                foreach (var kv in providerValues)
                                {
                                    sb.AppendLine($"      {kv.Key} = {kv.Value.ToHcl()}");
                                }
                            }
                            sb.AppendLine("    }");
                        }
                    }
                    sb.AppendLine("  }");
                }
                else
                {
                    sb.AppendLine($"  {kvp.Key} = {kvp.Value.ToHcl()}");
                }
            }

            // Handle Backend blocks
            foreach (var backend in Backends)
            {
                sb.AppendLine($"  backend \"{backend.Type}\" {{");
                if (backend.Body != null)
                {
                    foreach (var kvp in backend.Body)
                    {
                        sb.AppendLine($"    {kvp.Key} = {kvp.Value.ToHcl()}");
                    }
                }
                sb.AppendLine("  }");
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToJson()
        {
            var keyValuePairs = Body.Select(kvp => $"\"{kvp.Key}\": {kvp.Value.ToJson()}");
            var backendJson = Backends.Select(b =>
                $"{{ \"type\": \"{b.Type}\", \"body\": {{ {string.Join(", ", (b.Body ?? new Dictionary<string, HclValue>()).Select(kv => $"\"{kv.Key}\": {kv.Value.ToJson()}"))} }} }}"
            );

            return $"{{ \"terraform\": {{ {string.Join(", ", keyValuePairs)} {(Backends.Any() ? $", \"backend\": [{string.Join(", ", backendJson)}]" : "")} }} }}";
        }
    }

    public class Backend
    {
        public string Type { get; set; } = string.Empty;
        public Dictionary<string, HclValue>? Body { get; set; }
    }
}
