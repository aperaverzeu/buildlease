namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string DefaultImagePrefPath { get; set; } // path to an image that is to be displayed for the category's products that don't have an image
    }
}
