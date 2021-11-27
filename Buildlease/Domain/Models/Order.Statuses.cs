namespace Domain.Models
{
    public enum OrderStatus
    {
        Cart = 0,
        WaitingForApproval = 101,
        Approved = 102,
        DocumentPending = 103,
        InProcess = 104,
        Finished = 105,
        DeclinedByCustomer = 201,
        DeclinedByAdmin = 202,
    }

    public static class OrderStatusMetadata
    {
        public static readonly OrderStatus[] ReservationStatuses =
            new OrderStatus[]
            {
                OrderStatus.WaitingForApproval,
                OrderStatus.Approved,
                OrderStatus.DocumentPending,
                OrderStatus.InProcess,
            };
    }
}
