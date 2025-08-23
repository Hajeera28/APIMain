using APIMainProject.Models;

namespace APIMainProject.Interface
{
    public interface IHotel
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> AddHotels(Hotel hotel);
        Task<Hotel> UpdateHotels(int id, Hotel hotel);
        Task<Hotel> DeleteHotels(int id);
    }
}
