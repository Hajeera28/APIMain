using APIMainProject.Interface;
using APIMainProject.Models;
using APIMainProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIMainProject.Services
{
    public class UserService
    {
        private readonly IUser _repository;

        public UserService(IUser repository)
        {
            this._repository = repository;
        }
        public async Task<User> AddUsersAsync(User user)
        {
            return await _repository.AddUsers(user);
        }
        public async Task<User> DeleteUsersAsync(int id)
        {
            return await _repository.DeleteUsers(id);
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.GetUserById(id);
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsers();
        }
        public async Task<User> UpdateUsersAsync(int id, User user)
        {
            return await _repository.UpdateUsers(id, user);
        }
        public async Task<IEnumerable<User?>> SearchUsers(string keyword)
        {
            return await _repository.SearchUsers(keyword);
        }

    }
}
