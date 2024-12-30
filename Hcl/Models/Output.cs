using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModPosh.Hcl.Models
{
    public class Output : HclBlock
    {
        public HclValue? Value { get; set; }
    }
}
