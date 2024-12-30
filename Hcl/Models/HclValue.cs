using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class HclValue
    {
        public HclValueType Type { get; set; } // Type of the value
        public object? Value { get; set; } // The actual value, e.g., string, number, list, map
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
        Bool, // Add this
        Null,
        Unknown // Add this
    }
}
