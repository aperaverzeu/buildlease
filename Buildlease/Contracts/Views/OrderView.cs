using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime OrderAcceptDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public OrderStatus Status { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
        public ProductOrderView[] ProductOrders { get; set; }
    }
}
