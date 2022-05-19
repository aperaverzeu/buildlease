using System.Collections.Generic;
using Domain.Models;

namespace Domain.EntitiesExample
{
    public static class OrderEntities
    {
        public static List<Order> Get()
        {
            return new List<Order>()
            {
                new Order()
                {
                    Id = -1,
                    CustomerId = "user@mail.com",
                    Status = OrderStatus.WaitingForApproval //+
                },
                new Order()
                {
                    Id = -2,
                    CustomerId = "user@mail.com",
                    Status = OrderStatus.InProcess //+
                },
                new Order()
                {
                    Id = -3,
                    CustomerId = "user@mail.com",
                    Status = OrderStatus.InProcess //+
                },
                new Order()
                {
                    Id = -4,
                    CustomerId = "user@mail.com",
                    Status = OrderStatus.Finished //+
                },
                new Order()
                {
                    Id = -5,
                    CustomerId = "user@mail.com",
                    Status = OrderStatus.DeclinedByCustomer //+
                },
                new Order()
                {
                    Id = -6,
                    CustomerId = "admin@mail.com",
                    Status = OrderStatus.Cart //+
                },
                new Order()
                {
                    Id = -7,
                    CustomerId = "admin@mail.com",
                    Status = OrderStatus.InProcess //+
                },
            };
        }
    }
}