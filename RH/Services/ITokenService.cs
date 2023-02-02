using RH.Models;

namespace RH.Services
{
    public interface ITokenService
    {
        string GenerateToken(Employee employee);
    }
}
