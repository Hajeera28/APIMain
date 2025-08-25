using Microsoft.EntityFrameworkCore;
using APIMainProject.Interface;
using APIMainProject.Data;
using APIMainProject.Models;

namespace APIMainProject.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly HotelorderContext _context;

        public OrderRepository(HotelorderContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrders(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrders(int id)
        {
            var res = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(c => c.OrderId == id);

            if (res == null)
                throw new KeyNotFoundException($"Order with ID {id} not found");

            _context.Orders.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                  .Include(o => o.Hotel)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var res = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(h => h.OrderId == id);

            if (res == null)
                throw new KeyNotFoundException($"Order with ID {id} not found");

            return res;
        }

        public async Task<Order> UpdateOrders(int id, Order order)
        {
            var res = await _context.Orders 
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (res == null)
                throw new KeyNotFoundException($"Order with ID {id} not found");

            // Update order main properties
            res.OrderDate = order.OrderDate;
            res.OrderTime = order.OrderTime;
            res.OrderId = order.OrderId;
            res.Status = res.Status;
            res.HotelId = res.HotelId;

            // If you want to update OrderDetails also:
            if (order.OrderDetails != null && order.OrderDetails.Any())
            {
                res.OrderDetails.Clear();
                foreach (var detail in order.OrderDetails)
                {
                    res.OrderDetails.Add(detail);
                }
            }

            await _context.SaveChangesAsync();
            return res;
        }
    }
}
