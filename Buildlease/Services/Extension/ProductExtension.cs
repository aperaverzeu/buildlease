using Contracts.Views;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extension
{
    public static class ProductExtension
    {
        public static int GetProductAvailableCount(this ApplicationDbContext db, int productId)
            =>
                db.Orders
                .Where(e => OrderStatusMetadata.ReservationStatuses.Contains(e.Status))
                .Join(db.ProductOrders,
                    o => o.Id,
                    po => po.OrderId,
                    (o, po) => new
                    {
                        po.ProductId,
                        po.Count,
                    })
                .Where(obj => obj.ProductId == productId)
                .Sum(obj => obj.Count);
    }
}
