namespace Buildlease.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
