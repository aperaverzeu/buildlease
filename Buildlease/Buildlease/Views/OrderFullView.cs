using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class OrderFullView
    {
        public int Id { get; set; }
        public DateTime OrderAcceptDate { get; set; }
        public /*CommonOrderStatus*/ int Status { get; set; }
        public decimal Price { get; set; }
        public ProductOrderView[] ProductOrders { get; set; }
    }
}
