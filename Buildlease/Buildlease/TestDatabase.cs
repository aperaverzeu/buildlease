using Buildlease.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buildlease
{
    public static class TestDatabase
    {
        public static readonly List<Product> Products = new()
        {
            new()
            {
                Id = 69,
                CategoryId = 4,
                Name = "SCP-1876 - Личная зубная щётка",
            },
            new()
            {
                Id = 2,
                CategoryId = 3,
                Name = "Tooth-Brush™ с алмазным напылением",
            },
            new()
            {
                Id = 13,
                CategoryId = 2,
                Name = "Красная отвёртка",
            },
            new()
            {
                Id = 42,
                CategoryId = 2,
                Name = "Синяя отвёртка",
            },
            new()
            {
                Id = 1,
                CategoryId = 2,
                Name = "Зелёная отвёртка",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                ImagePath = "wwwroot/static/products/1.jpg",
                Count = 42,
                Price = 690.42M,
            }
        };

        public static readonly List<Category> Categories = new()
        {
            new()
            {
                Id = 0,
                ParentId = 0,
                Name = "Все",
            },
            new()
            {
                Id = 2,
                ParentId = 0,
                Name = "Зубные щётки",
            },
            new()
            {
                Id = 42,
                ParentId = 2,
                Name = "Электрические",
            },
            new()
            {
                Id = 10,
                ParentId = 0,
                Name = "Отвёртки",
            },
            new()
            {
                Id = 3,
                ParentId = 2,
                Name = "Механические",
            },
        };

        public static readonly List<ProductOrder> ProductOrders = new()
        {
            new ProductOrder()
            {
                Id = 13,
                OrderId = 13,
                ProductId = 13,
                Count = 42,
                Status = CommonOrderStatus.Cart,
            },
            new ProductOrder()
            {
                Id = 42,
                OrderId = 13,
                ProductId = 1,
                Count = 1,
                Status = CommonOrderStatus.Cart,
            },
            new ProductOrder()
            {
                Id = 13,
                OrderId = 13,
                ProductId = 2,
                Count = 69420,
                Status = CommonOrderStatus.Cart,
            },
        };

        public static readonly List<Order> Orders = new()
        {
            new Order()
            {
                Id = 13,
                CustomerId = 42,
                Status = CommonOrderStatus.Cart,
            },
            new Order()
            {
                Id = 23,
                CustomerId = 42,
                Status = CommonOrderStatus.InProcess,
            },
            new Order()
            {
                Id = 69,
                CustomerId = 42,
                Status = CommonOrderStatus.Finished,
            },
        };

    }
}
