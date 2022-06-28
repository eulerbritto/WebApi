using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Lead;

public class LeadRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public DateTime? DateCreated { get; set; }
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