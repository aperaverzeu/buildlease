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
    public static class OrderExtension
    {
        public static Order ValidateAndGetCart(this ApplicationDbContext db, string userId)
        {
            if (userId is null) return null;

            var carts = db.Orders
                .Where(e => e.CustomerId == userId)
                .Where(e => e.Status == OrderStatus.Cart);

            if (carts.Count() != 1)
            {
                db.Orders.RemoveRange(carts);
                db.Orders.Add(new Order() { 
                    CustomerId = userId, 
                    Status = OrderStatus.Cart,
                });
                db.SaveChanges();
            }

            var cart = db.Orders
                .IncludeProductOrderView()
                .Where(e => e.CustomerId == userId)
                .Single(e => e.Status == OrderStatus.Cart);

            var deletedProducts = cart.ProductOrders.Where(e => e.ProductId == null);

            if (deletedProducts.Any())
            {
                db.ProductOrders.RemoveRange(deletedProducts);
                db.SaveChanges();
                throw new ArgumentNullException("There was deleted products in your cart");
            }

            return cart;
        }
    }
}
