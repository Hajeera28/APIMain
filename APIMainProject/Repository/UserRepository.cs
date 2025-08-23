using Microsoft.EntityFrameworkCore;
using APIMainProject.Interface;
using APIMainProject.Data;
using APIMainProject.Models;

namespace APIMainProject.Repository
{
    public class UserRepository : IUser
    {
        private readonly HotelorderContext _hotelorderContext;

        public UserRepository(HotelorderContext hotelorderContext)
        {
            _hotelorderContext = hotelorderContext;
        }

        public async Task<User> AddUsers(User user)
        {
            await _hotelorderContext.Users.AddAsync(user);
            await _hotelorderContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUsers(int id)
        {
            var res = await _hotelorderContext.Users
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(c => c.UserId == id);

            if (res == null)
                throw new KeyNotFoundException($"User with Id {id} not found");

            _hotelorderContext.Users.Remove(res);
            await _hotelorderContext.SaveChangesAsync();
            return res;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _hotelorderContext.Users
                .Include(u => u.Orders).ThenInclude(o => o.Hotel).
                Include(u => u.Orders)
        .ThenInclude(o => o.OrderDetails).ToListAsync();
            // User → Orders → Hotel

        }

        public async Task<User> GetUserById(int id)
        {
            var res = await _hotelorderContext.Users.Include(u => u.Orders).ThenInclude(o => o.Hotel).FirstOrDefaultAsync(h => h.UserId == id);

            if (res == null)
                throw new KeyNotFoundException($"User with Id {id} not found");

            return res;
        }

        public async Task<User> UpdateUsers(int id, User user)
        {
            var res = await _hotelorderContext.Users.FindAsync(id);

            if (res == null)
                throw new KeyNotFoundException($"User with Id {id} not found");

            res.UserName = user.UserName;
            res.Email = user.Email;
            res.Password = user.Password;
            res.Phone = user.Phone;

            await _hotelorderContext.SaveChangesAsync();
            return res;
        }
    }
}
