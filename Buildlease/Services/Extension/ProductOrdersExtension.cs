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
    public static class ProductOrdersExtension
    {
        public static ProductOrderView[] GetProductOrderViews(
            this ApplicationDbContext db,
            int orderId)
            =>
                db.ProductOrders
                .Where(e => e.OrderId == orderId)
                .ToProductOrderViews(db)
                .ToArray();

        public static IQueryable<ProductOrderView> ToProductOrderViews(
            this IQueryable<ProductOrder> ProductOrders, 
            ApplicationDbContext db)
            =>
            ProductOrders
                .Join(db.Products,
                    po => po.ProductId,
                    p => p.Id,
                    (po, p) => new ProductOrderView()
                    {
                        ProductId = p.Id,
                        Count = po.Count,
                        Name = p.Name,
                        ImagePath = p.ImagePath,
                        Price = p.Price.Value,
                        Attributes = db.GetProductAttributeViews(p.Id),
                    }
                );
    }
}
