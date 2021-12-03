using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public class GetProductsRequest
    {
        public int CategoryId { get; set; }
        public string[] Keywords { get; set; }
        public AttributeFilter[] Filters { get; set; }
        public decimal? MaxPrice { get; set; }
        public SortRule OrderByRule { get; set; }
        public int SkipCount { get; set; }
        public int TakeCount { get; set; }
    }
}
