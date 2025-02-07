using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModPosh.Hcl.Models
{
    public class HclValue
    {
        public HclValueType Type { get; set; }
        public object? Value { get; set; }

        public string ToHcl()
        {
            var debugInfo = new StringBuilder($"[DEBUG] Processing HclValue of type {Type} with value: {Value}\n");

            try
            {
                switch (Type)
                {
                    case HclValueType.String:
                        debugInfo.AppendLine("[DEBUG] Handling String type.");
                        return $"\"{Value}\"";

                    case HclValueType.Number:
                    case HclValueType.Boolean:
                        debugInfo.AppendLine("[DEBUG] Handling Number/Boolean type.");
                        return Value?.ToString()?.ToLowerInvariant() ?? "null";

                    case HclValueType.List:
                        debugInfo.AppendLine("[DEBUG] Handling List type.");
                        if (Value is List<HclValue> hclList)
                        {
                            debugInfo.AppendLine($"[DEBUG] Expanding List<HclValue> with {hclList.Count} items.");
                            return $"[{string.Join(", ", hclList.Select(v => v.ToHcl()))}]";
                        }
                        else if (Value is List<Dictionary<string, HclValue>> dictList)
                        {
                            debugInfo.AppendLine($"[DEBUG] Expanding List<Dictionary<string, HclValue>> with {dictList.Count} items.");
                            var sb = new StringBuilder();
                            foreach (var dict in dictList)
                            {
                                sb.AppendLine("{");
                                foreach (var kvp in dict.Where(kvp => kvp.Key != "type" && kvp.Key != "name" && kvp.Key != "body"))
                                {
                                    sb.AppendLine($"  {kvp.Key} = {kvp.Value.ToHcl()}");
                                }
                                sb.AppendLine("}");
                            }
                            return sb.ToString().TrimEnd();
                        }
                        debugInfo.AppendLine("[DEBUG] Value is not a List<HclValue> or List<Dictionary<string, HclValue>>.");
                        return "[]";

                    case HclValueType.Map:
                        debugInfo.AppendLine("[DEBUG] Handling Map type.");
                        if (Value is Dictionary<string, HclValue> map)
                        {
                            var sb = new StringBuilder("{\n");
                            foreach (var kvp in map.Where(kvp => kvp.Key != "type" && kvp.Key != "name" && kvp.Key != "body"))
                            {
                                sb.AppendLine($"  {kvp.Key} = {kvp.Value.ToHcl()},");
                            }
                            sb.AppendLine("}");
                            return sb.ToString().TrimEnd();
                        }
                        debugInfo.AppendLine("[DEBUG] Value is not a Dictionary<string, HclValue>.");
                        return "{}";

                    default:
                        debugInfo.AppendLine("[DEBUG] Unhandled type or null value.");
                        return Value?.ToString() ?? "null";
                }
            }
            catch (Exception ex)
            {
                debugInfo.AppendLine($"[DEBUG] Exception encountered: {ex.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine(debugInfo.ToString());
            }
        }

        public object? ToJson()
        {
            switch (Type)
            {
                case HclValueType.List:
                    return Value is List<HclValue> list ? list.Select(v => v.ToJson()).ToList() : null;
                case HclValueType.Map:
                    return Value is Dictionary<string, HclValue> map
                        ? map.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToJson())
                        : null;
                default:
                    return Value;
            }
        }
    }

    public enum HclValueType
    {
        String,
        Number,
        Boolean,
        List,
        Map,
        Reference,
        FunctionCall,
        Bool,
        Null,
        Unknown
    }
}
