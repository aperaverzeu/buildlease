namespace Buildlease.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public decimal? ValueNumber { get; set; }
        public string ValueString { get; set; }
    }
}
