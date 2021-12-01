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
                    CustomerId = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    Status = OrderStatus.WaitingForApproval //+
                },
                new Order()
                {
                    Id = -2,
                    CustomerId = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    Status = OrderStatus.InProcess //+
                },
                new Order()
                {
                    Id = -3,
                    CustomerId = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    Status = OrderStatus.InProcess //+
                },
                new Order()
                {
                    Id = -4,
                    CustomerId = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    Status = OrderStatus.Finished //+
                },
                new Order()
                {
                    Id = -5,
                    CustomerId = "c65e9a5d-ef9f-450b-b851-f97190da3470",
                    Status = OrderStatus.DeclinedByCustomer //+
                },
                new Order()
                {
                    Id = -6,
                    CustomerId = "f92039fd-5e51-431e-aefe-4a18e6cc846a",
                    Status = OrderStatus.Cart //+
                },
                new Order()
                {
                    Id = -7,
                    CustomerId = "f92039fd-5e51-431e-aefe-4a18e6cc846a",
                    Status = OrderStatus.InProcess //+
                },
            };
        }
    }
}