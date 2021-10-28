namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerFullView { get; set; }
    }
}
