using APIMainProject.Models;
using APIMainProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMainProject.Services
{
    public class OrderDetailService
    {
        private readonly OrderDetailRepository _repository;

        public OrderDetailService(OrderDetailRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync()
        {
            return await _repository.GetAllOrderDetails();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _repository.GetOrderDetailById(id);
        }

        public async Task<OrderDetail> AddOrderDetailsAsync(OrderDetail orderdetail)
        {
            return await _repository.AddOrderDetails(orderdetail);
        }

        public async Task<OrderDetail> DeleteOrderDetailsAsync(int id)
        {
            return await _repository.DeleteOrderDetails(id);
        }

        public async Task<OrderDetail> UpdateOrderDetailsAsync(int id, OrderDetail orderDetail)
        {
            return await _repository.UpdateOrderDetails(id, orderDetail);
        }
    }
}