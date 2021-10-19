using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime OrderAcceptDate { get; set; }
        public /*CommonOrderStatus*/ int Status { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
    }
}
