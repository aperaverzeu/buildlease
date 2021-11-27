using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Models.Historicity;

namespace Domain.EntitiesExample
{
    public static class OrderStatusHistoryEntities
    {
        public static List<HistoryOfOrderStatus> Get()
        {
            return new List<HistoryOfOrderStatus>()
            {
                new HistoryOfOrderStatus()
                {
                    Id = 1,
                    OrderId = 4,
                    Date = new DateTime(2020, 9, 20),
                    NewStatus = OrderStatus.WaitingForApproval
                },
                new HistoryOfOrderStatus()
                {
                    Id = 2,
                    OrderId = 4,
                    Date = new DateTime(2020, 9, 25),
                    NewStatus = OrderStatus.Approved
                },
                new HistoryOfOrderStatus()
                {
                    Id = 3,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 11),
                    NewStatus = OrderStatus.DocumentPending
                },
                new HistoryOfOrderStatus()
                {
                    Id = 4,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 12),
                    NewStatus = OrderStatus.InProcess
                },
                new HistoryOfOrderStatus()
                {
                    Id = 1,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 25),
                    NewStatus = OrderStatus.Finished
                }
            };
        }
    }
}