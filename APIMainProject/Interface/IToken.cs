using APIMainProject.Models;

namespace APIMainProject.Interface
{
    public interface IToken
    {
        public string GenerateToken(User user);
    }
}
