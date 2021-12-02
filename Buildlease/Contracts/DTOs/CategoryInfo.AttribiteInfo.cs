using Domain.Models;

namespace Contracts.DTOs
{
    public class AttributeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AttributeType ValueType { get; set; }
        public string UnitName { get; set; }
    }
}
