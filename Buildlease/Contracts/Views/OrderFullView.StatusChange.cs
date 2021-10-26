using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Views
{
    public class StatusChangeView
    {
        public DateTime Date { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
