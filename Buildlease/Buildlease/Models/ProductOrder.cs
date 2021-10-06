namespace Buildlease.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public CommonOrderStatus Status { get; set; }
    }
}
