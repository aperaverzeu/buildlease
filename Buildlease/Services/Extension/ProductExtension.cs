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
            => (
                db.Products.Single(e => e.Id == productId).TotalCount
            -
                db.Orders
                .Where(e => OrderStatusMetadata.ReservationStatuses.Contains(e.Status))
                .SelectMany(e => e.ProductOrders)
                .Where(e => e.ProductId == productId)
                .Sum(e => e.Count)
            );
    }
}
