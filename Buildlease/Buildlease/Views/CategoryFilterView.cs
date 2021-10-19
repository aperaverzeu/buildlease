using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class CategoryFilterView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UnitName { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string[] Values { get; set; }
    }
}
