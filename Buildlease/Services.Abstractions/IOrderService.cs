using Contracts.Views;

namespace Services.Abstractions
{
    public interface IOrderService
    {
        OrderView[] GetMyOrders();
        OrderFullView GetOrder(int orderId);
        CartFullView GetMyCart();
    }
}
