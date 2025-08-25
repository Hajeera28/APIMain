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
    public class UserController : ControllerBase
    {
        private readonly UserService _res;

        public UserController(UserService res)
        {
            this._res = res;
        }

       
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _res.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        
        public async Task<User> GetUserById(int id)
        {
            return await _res.GetUserByIdAsync(id);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<User?>> SearchUsers([FromQuery] string keyword)
        {
            return await _res.SearchUsers(keyword);
        }

        [HttpPost]
       
        public async Task<User> AddUsers(UserDto dto)
        {
            User usr = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone,
            };
            return await _res.AddUsersAsync(usr);
        }


        [HttpPut]
       
        public async Task<User> UpdateUsers(int id, User user)
        {
            return await _res.UpdateUsersAsync(id, user);
        }

        [HttpDelete]
        public async Task<User> DeleteUsers(int id)
        {
            return await _res.DeleteUsersAsync(id);
        }



    }
}
