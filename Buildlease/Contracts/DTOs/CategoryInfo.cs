namespace Contracts.DTOs
{
    public class CategoryInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLink { get; set; }
        public AttributeInfo[] Attributes { get; set; }
    }
}
