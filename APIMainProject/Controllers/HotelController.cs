using APIMainProject.Models;
using APIMainProject.Repository;
using APIMainProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIMainProject.DTO;

namespace APIMainProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _res;

        public HotelController(HotelService res)
        {
            this._res = res;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _res.GetAllHotelsAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Customer")]
        public async Task<Hotel> GetHotelById(int id)
        {
            return await _res.GetHotelByIdAsync(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Hotel> AddHotel(HotelDtocs dto)
        {
            Hotel hot = new Hotel
            {
                HotelName = dto.HotelName,
                Location=dto.Location,
                Contact=dto.Contact,
                Rating=dto.Rating

            };
            return await _res.AddHotelsAsync(hot);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            return await _res.UpdateHotelsAsync(id, hotel);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<Hotel> DeleteHotel(int id)
        {
            return await _res.DeleteHotelsAsync(id);
        }
    }
}
