using OrderPlanner.Models;

namespace OrderPlanner.Services
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderAsync(Guid orderId);
        Task<IEnumerable<Order>> GetOrdersAsync();
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        Task<bool> SaveChangesAsync();

    }
}
