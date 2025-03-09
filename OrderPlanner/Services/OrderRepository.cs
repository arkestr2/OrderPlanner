using Microsoft.EntityFrameworkCore;
using OrderPlanner.DbContexts;
using OrderPlanner.Models;

namespace OrderPlanner.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order?> GetOrderAsync(Guid orderId)
        {
            return await _context.Orders
                .Where(c => c.Id == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.OrderBy(o => o.PickupDate).ToListAsync();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }
        public void DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
