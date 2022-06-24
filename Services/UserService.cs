using AutoMapper;
using Crypt = BCrypt.Net.BCrypt;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Interfaces;

namespace WebApi.Services;

public class UserService : IUserService
{
    private DataContext _context;
    private IJwt _jwt;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IJwt jwt,
        IMapper mapper)
    {
        _context = context;
        _jwt = jwt;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username.Equals(model.Username));

        if (user is null || !Crypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Falha na autenticação. Verifique os dados.");

        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwt.GenerateToken(user);
        return response;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return GetUser(id);
    }

    public void Register(RegisterRequest model)
    {
        if (_context.Users.Any(x => x.Username.Equals(model.Username)))
            throw new AppException($"Login {model.Username} já existente.");

        var user = _mapper.Map<User>(model);

        user.PasswordHash = Crypt.HashPassword(model.Password);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var user = GetUser(id);

        if (!model.Username.Equals(user.Username) && 
            _context.Users.Any(x => x.Username.Equals(model.Username)))
            throw new AppException("Login já está em uso.");

        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = Crypt.HashPassword(model.Password);

        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = GetUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    private User GetUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user is null) 
            throw new KeyNotFoundException("Usuário não encontrado.");
        return user;
    }
}