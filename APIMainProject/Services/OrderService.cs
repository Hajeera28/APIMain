using APIMainProject.Interface;
using APIMainProject.Models;
using APIMainProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMainProject.Services
{
    public class OrderService
    {
        private readonly IOrder _repository;

        public OrderService(IOrder repository)
        {
            this._repository = repository;
        }

        public async Task<Order> AddOrdersAsync(Order order)
        {
            return await _repository.AddOrders(order);
        }

        public async Task<Order> DeleteOrdersAsync(int id)
        {
            return await _repository.DeleteOrders(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        { 
            return await _repository.GetAllOrders();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _repository.GetOrderById(id);
        }
        public async Task<Order> UpdateOrdersAsync(int id, Order order)
        {
            return await _repository.UpdateOrders(id, order);
        }
    }
}
