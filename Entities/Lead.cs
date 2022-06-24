using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Entities;

public class Lead
{
    [Required]
    public int Id { get; set; }
    [Required] 
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    [Required]
    public string Suburb { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Status { get; set; }
}