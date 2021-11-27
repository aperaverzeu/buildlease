﻿using System;
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
                    Date = new DateTime(2020, 9, 20, 18, 22, 0),
                    NewStatus = OrderStatus.WaitingForApproval
                },
                new HistoryOfOrderStatus()
                {
                    Id = 2,
                    OrderId = 4,
                    Date = new DateTime(2020, 9, 25, 14, 14, 0),
                    NewStatus = OrderStatus.Approved
                },
                new HistoryOfOrderStatus()
                {
                    Id = 3,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 11, 12, 30, 0),
                    NewStatus = OrderStatus.DocumentPending
                },
                new HistoryOfOrderStatus()
                {
                    Id = 4,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 12, 13, 0, 0),
                    NewStatus = OrderStatus.InProcess
                },
                new HistoryOfOrderStatus()
                {
                    Id = 5,
                    OrderId = 4,
                    Date = new DateTime(2020, 10, 25, 19, 12, 0),
                    NewStatus = OrderStatus.Finished
                }
            };
        }
    }
}