using AdoptMe.Repository.Models;

namespace AdoptMe.Service.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string userRole, int shelterId);
        TokenValidatorResult ValidateToken(string token);
    }
}
