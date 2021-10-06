namespace Buildlease.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CommonOrderStatus Status { get; set; }
    }
}
