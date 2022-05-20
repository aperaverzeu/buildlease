using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class ProductFullView
    {
        public int Id { get; set; }
        public CategoryView[] CategoryPath { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
        public decimal? Price { get; set; }
        public ProductAttributeView[] Attributes { get; set; }
        public int CountInCart { get; set; }
        public ProductDescriptionView[] Descriptions { get; set; }
    }
}
