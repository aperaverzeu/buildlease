using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IMakingOrderService
    {
        void SetProductOrderCount(string userId, int productId, int count);
        void MakeOrderFromCart(string userId, DateTime startDate, DateTime finishDate);
        void DeclineOrder(string userId, int orderId);
    }
}
