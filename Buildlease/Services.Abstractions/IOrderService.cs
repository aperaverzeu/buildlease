using Contracts.Views;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        OrderView[] GetMyOrders(string userId);
        OrderFullView GetOrder(string userId, int orderId);
        CartFullView GetMyCart(string userId);
    }
}
