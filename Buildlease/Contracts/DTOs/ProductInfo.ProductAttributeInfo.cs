using Domain.Models;

namespace Contracts.DTOs
{
    public class ProductAttributeInfo
    {
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public AttributeType ValueType { get; set; }

        public string UnitName { get; set; }
        // or
        public string[] ExistingStringValues { get; set; }

        public string Value { get; set; }
    }
}
