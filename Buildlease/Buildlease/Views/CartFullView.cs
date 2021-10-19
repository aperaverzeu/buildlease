using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease.Views
{
    public class CartFullView
    {
        public decimal Price { get; set; }
        public ProductOrderView[] ProductOrders { get; set; }
    }
}
