using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class OrderFullView
    {
        public int Id { get; set; }
        public StatusChangeView[] StatusHistory { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public decimal Price { get; set; }
        public ProductOrderView[] ProductOrders { get; set; }
    }
}
