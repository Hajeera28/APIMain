using APIMainProject.Models;

namespace APIMainProject.Interface
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUsers(User user);
        Task<User> UpdateUsers(int id,User user);
        Task<User> DeleteUsers(int id);

        Task<IEnumerable<User?>> SearchUsers(string keyword);
    }
}
