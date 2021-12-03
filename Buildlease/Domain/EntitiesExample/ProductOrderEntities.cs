using System.Collections.Generic;
using Domain.Models;

namespace Domain.EntitiesExample
{
    public static class ProductOrderEntities
    {
        public static List<ProductOrder> Get()
        {
            return new List<ProductOrder>()
            {
                new ProductOrder()
                {
                    Id = -1,
                    OrderId = -6,
                    ProductId = -12,
                    Count = 2000
                },
                new ProductOrder()
                {
                    Id = -2,
                    OrderId = -6,
                    ProductId = -1,
                    Count = 1
                },
                new ProductOrder()
                {
                    Id = -3,
                    OrderId = -4,
                    ProductId = -1,
                    Count = 10000
                },
                new ProductOrder()
                {
                    Id = -4,
                    OrderId = -5,
                    ProductId = -12,
                    Count = 33
                },
                new ProductOrder()
                {
                    Id = -5,
                    OrderId = -1,
                    ProductId = -1,
                    Count = 44
                },
                new ProductOrder()
                {
                    Id = -6,
                    OrderId = -2,
                    ProductId = -12,
                    Count = 1000
                },
                new ProductOrder()
                {
                    Id = -7,
                    OrderId = -3,
                    ProductId = -12,
                    Count = 556
                },
                new ProductOrder()
                {
                    Id = -8,
                    OrderId = -7,
                    ProductId = -1,
                    Count = 369
                },
                new ProductOrder()
                {
                    Id = -9,
                    OrderId = -7,
                    ProductId = -12,
                    Count = 668
                },
            };
        }
    }
}