using APIMainProject.Models;
using APIMainProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMainProject.Services
{
    public class HotelService
    {
        private readonly HotelRepository _repository;

        public HotelService(HotelRepository repository)
        {
            this._repository = repository;
        }

        public async Task<Hotel> AddHotelsAsync(Hotel hotel)
        {
            return await _repository.AddHotels(hotel);
        }

        public async Task<Hotel> DeleteHotelsAsync(int id)
        {
            return await _repository.DeleteHotels(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _repository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            return await _repository.GetHotelById(id);
        }

        public async Task<Hotel> UpdateHotelsAsync(int id, Hotel hotel)
        {
            return await _repository.UpdateHotels(id, hotel);
        }
    }
}
