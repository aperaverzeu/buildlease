using System;

namespace Domain.Models.Historicity
{
    public class HistoryOfOrderStatus
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
