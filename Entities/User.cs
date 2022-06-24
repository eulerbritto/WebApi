using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Entities;

public class User
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }

    [Required]
    [JsonIgnore]
    public string PasswordHash { get; set; }
}