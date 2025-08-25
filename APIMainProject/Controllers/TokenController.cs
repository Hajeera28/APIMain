using APIMainProject.Interface;
using APIMainProject.Models;
using Microsoft.AspNetCore.Mvc;
using APIMainProject.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly HotelorderContext _con;
    private readonly IToken _tokenService;
    public TokenController(HotelorderContext con, IToken tokenService)
    {
        _con = con;
        _tokenService = tokenService;
    }
    [HttpPost]
    public async Task<IActionResult> Post(User userData)
    {
        if (userData != null && !string.IsNullOrEmpty(userData.Email) &&
        !string.IsNullOrEmpty(userData.Password))
        {
            var user = await GetUser(userData.Email, userData.Password);
            if (user != null)
            {
                var token = _tokenService.GenerateToken(user);

                return Ok(new { token });

            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest("Invalid request data");
        }
    }
    private async Task<User> GetUser(string email, string password)
    {
        return await _con.Users.FirstOrDefaultAsync(u => u.Email == email &&
        u.Password == password) ?? new APIMainProject.Models.User();
    }
}