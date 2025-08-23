using APIMainProject.Models;

namespace APIMainProject.Interface
{
    public interface IOrderDetail
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int id);
        Task<OrderDetail> AddOrderDetails(OrderDetail orderdetail);
        Task<OrderDetail> UpdateOrderDetails(int id,OrderDetail orderDetail);
        Task<OrderDetail> DeleteOrderDetails(int id); 
    }
}
