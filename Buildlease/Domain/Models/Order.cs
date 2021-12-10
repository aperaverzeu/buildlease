using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public string SerializedCustomerInfo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public Customer Customer { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public IEnumerable<HistoryOfOrderStatus> HistoryOfOrderStatus { get; set; }
    }
}
