namespace Buildlease.Models
{
    public enum CommonOrderStatus
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
}
