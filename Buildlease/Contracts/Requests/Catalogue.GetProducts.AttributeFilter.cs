using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public class AttributeFilter
    {
        public int AttributeId { get; set; }
        public decimal? ValueNumberLowerBound { get; set; }
        public decimal? ValueNumberUpperBound { get; set; }
        public string[] ValueStringAllowed { get; set; }
    }
}
