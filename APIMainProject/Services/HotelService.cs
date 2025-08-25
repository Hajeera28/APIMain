using APIMainProject.Interface;
using APIMainProject.Models;
using APIMainProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMainProject.Services
{
    public class HotelService
    {
        private readonly IHotel _repository;

        public HotelService(IHotel repository)
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

        public async Task<IEnumerable<Hotel>> SearchHotelsAsync(string keyword)
        {
            return await _repository.SearchHotels(keyword);
        }
    }
}
