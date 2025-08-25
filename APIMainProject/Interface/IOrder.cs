using APIMainProject.Models;

namespace APIMainProject.Interface
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> AddOrders(Order order);
        Task<Order> UpdateOrders(int id,Order order);
        Task<Order> DeleteOrders(int id);
    }
}
