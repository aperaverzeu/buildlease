namespace Domain.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public AttributeType ValueType { get; set; }
        public string UnitName { get; set; }

        public Category Category { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}
