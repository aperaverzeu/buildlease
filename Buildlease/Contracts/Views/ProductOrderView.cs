using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class ProductOrderView
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
