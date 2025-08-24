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
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _res;

        public OrderDetailController(OrderDetailService res)
        {
            this._res = res;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await _res.GetAllOrderDetailsAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _res.GetOrderDetailByIdAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<OrderDetail> AddOrderDetails(OrderDetailDto dto)
        {
            OrderDetail orddet = new OrderDetail
            {
                ItemName=dto.ItemName,
                Quantity=dto.Quantity,
                Price=dto.Price,
                PaymentMethod=dto.PaymentMethod,
            };
            return await _res.AddOrderDetailsAsync(orddet);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<OrderDetail> UpdateOrderDetails(int id, OrderDetail orderDetail)
        {
            return await _res.UpdateOrderDetailsAsync(id, orderDetail);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<OrderDetail> DeleteOrderDetails(int id)
        {
            return await _res.DeleteOrderDetailsAsync(id);
        }

       

    }
}
