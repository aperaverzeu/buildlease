using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public int AvalableCount { get; set; }
        public decimal? Price { get; set; }
        public bool AlreadyInCart { get; set; }
    }
}
