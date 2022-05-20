namespace Domain.Models
{
    public class ProductDescription
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int LanguageId { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }
        public Language Language { get; set; }
    }
}
