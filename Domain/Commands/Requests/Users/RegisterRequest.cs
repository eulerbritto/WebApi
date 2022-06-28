namespace WebApi.Models.Users;

using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApi.Domain.Commands.Requests;

public class RegisterRequest : IRequest<CreateUserResponse>
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}