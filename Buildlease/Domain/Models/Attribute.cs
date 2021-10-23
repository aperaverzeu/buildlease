namespace Domain.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AttributeType ValueType { get; set; }
        public string UnitName { get; set; }
    }
}
