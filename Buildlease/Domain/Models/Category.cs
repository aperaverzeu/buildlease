using System.Collections.Generic;

namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string DefaultImagePath { get; set; }

        public Category ParentCategory { get; set; }
        public IEnumerable<Category> SubCategories { get; set; }
        public IEnumerable<Attribute> Attributes { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
