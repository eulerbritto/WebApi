using WebApi.Entities;

namespace WebApi.Interfaces;

public interface IJwt
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}
