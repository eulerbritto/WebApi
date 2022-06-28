using MediatR;
using WebApi.Domain.Commands.Requests;

namespace WebApi.Models.Users;

public class UpdateRequest : IRequest<CreateUserResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}