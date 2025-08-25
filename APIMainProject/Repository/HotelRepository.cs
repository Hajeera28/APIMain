using Microsoft.EntityFrameworkCore;
using APIMainProject.Interface;
using APIMainProject.Data;
using APIMainProject.Models;

namespace APIMainProject.Repository
{
    public class HotelRepository : IHotel
    {
        private readonly HotelorderContext _hotelorder;

        public HotelRepository(HotelorderContext hotelorder)
        {
            _hotelorder = hotelorder;
        }

        public async Task<Hotel> AddHotels(Hotel hotel)
        {
            await _hotelorder.Hotels.AddAsync(hotel);
            await _hotelorder.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotels(int id)
        {
            var res = await _hotelorder.Hotels
                .Include(h => h.Orders)   // Hotel → Orders
                .FirstOrDefaultAsync(c => c.HotelId == id);

            if (res != null)
            {
                _hotelorder.Hotels.Remove(res);
                await _hotelorder.SaveChangesAsync();
            }
            return res;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _hotelorder.Hotels
               .Include(h => h.Orders)
            .ThenInclude(o => o.User)   
        .Include(h => h.Orders)
            .ThenInclude(o => o.OrderDetails) 
        .ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            var hotel = await _hotelorder.Hotels
                .Include(h => h.Orders)
                .FirstOrDefaultAsync(h => h.HotelId == id);

            if (hotel == null)
                throw new KeyNotFoundException($"Hotel with Id {id} not found");

            return hotel;
        }

        public async Task<Hotel> UpdateHotels(int id, Hotel hotel)
        {
            var res = await _hotelorder.Hotels.FindAsync(id);
            if (res != null)
            {
                res.HotelName = hotel.HotelName;
                res.Location = hotel.Location;
                res.Contact = hotel.Contact;
                res.Rating = hotel.Rating;
                await _hotelorder.SaveChangesAsync();
            }
            return res;
        }

        public async Task<IEnumerable<Hotel?>> SearchHotels(string keyword)
        {
            var res = await _hotelorder.Hotels
                .Where(h => h.HotelName.Contains(keyword) ||
                            h.Location.Contains(keyword) ||
                            h.Contact.Contains(keyword))
                .Include(h => h.Orders)                     // Load Orders
            .ThenInclude(o => o.User)               // Load User inside Orders
        .Include(h => h.Orders)
            .ThenInclude(o => o.OrderDetails)
                .ToListAsync();

            return res;
        }

    }
}
