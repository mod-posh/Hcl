using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModPosh.Hcl.Utilities
{
    public static class Converters
    {
        public static string SerializeListToHcl(List<object> list)
        {
            return $"[{string.Join(", ", list.Select(v => $"\"{v}\""))}]";
        }

        public static string SerializeMapToHcl(Dictionary<string, object> map)
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            foreach (var kvp in map)
            {
                sb.AppendLine($"  {kvp.Key} = \"{kvp.Value}\"");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
