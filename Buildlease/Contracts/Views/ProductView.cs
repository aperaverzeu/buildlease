using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductAttributeView[] Attributes { get; set; }
        public string ImagePath { get; set; }
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }     
        public decimal? Price { get; set; }
        public bool AlreadyInCart { get; set; }
    }
}
