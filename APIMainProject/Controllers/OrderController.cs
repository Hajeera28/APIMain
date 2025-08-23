using APIMainProject.Models;
using APIMainProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMainProject.DTO;

namespace APIMainProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _res;

        public OrderController(OrderService res)
        {
            this._res = res;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<Order> AddOrdersAsync(OrderDto dto)
        {
            Order ord = new Order
            {
                OrderDate = dto.OrderDate,
                OrderTime=dto.OrderTime,
                Status=dto.Status,
            };
            return await _res.AddOrdersAsync(ord);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<Order> DeleteOrdersAsync(int id)
        {
            return await _res.DeleteOrdersAsync(id);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _res.GetAllOrdersAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _res.GetOrderByIdAsync(id);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<Order> UpdateOrders(int id, Order order)
        {
            return await _res.UpdateOrdersAsync(id, order);
        }
    }
}
