using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class CategoryView
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public string DefaultImagePath { get; set; }
    }
}
