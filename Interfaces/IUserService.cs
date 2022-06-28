using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Interfaces;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    User Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}
