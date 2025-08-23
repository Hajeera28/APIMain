using Microsoft.EntityFrameworkCore;
using APIMainProject.Interface;
using APIMainProject.Data;
using APIMainProject.Models;

namespace APIMainProject.Repository
{
    public class OrderDetailRepository : IOrderDetail
    {
        private readonly HotelorderContext _hotelorderContext;

        public OrderDetailRepository(HotelorderContext hotelorderContext)
        {
            _hotelorderContext = hotelorderContext;
        }

        public async Task<OrderDetail> AddOrderDetails(OrderDetail orderdetail)
        {
            await _hotelorderContext.OrderDetails.AddAsync(orderdetail);
            await _hotelorderContext.SaveChangesAsync();
            return orderdetail;
        }

        public async Task<OrderDetail> DeleteOrderDetails(int id)
        {
            var res = await _hotelorderContext.OrderDetails
                .Include(od => od.Order)               // include Order
                    .ThenInclude(o => o.User)          // include User inside Order
                .FirstOrDefaultAsync(c => c.OrderDetailId == id);

            if (res == null)
                throw new KeyNotFoundException($"OrderDetail with ID {id} not found");

            _hotelorderContext.OrderDetails.Remove(res);
            await _hotelorderContext.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await _hotelorderContext.OrderDetails
                 .Include(od => od.Order)                 // include Order
            .ThenInclude(o => o.Hotel)           // then include Hotel from Order
        .Include(od => od.Order)
            .ThenInclude(o => o.User)            // optional: include User too
                     
       
                .ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            var res = await _hotelorderContext.OrderDetails
                .Include(od => od.Order)               // include Order
                    .ThenInclude(o => o.User)          // include User inside Order
                .FirstOrDefaultAsync(h => h.OrderDetailId == id);

            if (res == null)
                throw new KeyNotFoundException($"OrderDetail with ID {id} not found");

            return res;
        }

        public async Task<OrderDetail> UpdateOrderDetails(int id, OrderDetail orderDetail)
        {
            var res = await _hotelorderContext.OrderDetails.FindAsync(id);

            if (res == null)
                throw new KeyNotFoundException($"OrderDetail with ID {id} not found");

            res.ItemName = orderDetail.ItemName;
            res.PaymentMethod = orderDetail.PaymentMethod;
            res.Price = orderDetail.Price;
            res.Quantity = orderDetail.Quantity;

            await _hotelorderContext.SaveChangesAsync();
            return res;
        }
    }
}
