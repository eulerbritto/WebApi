namespace WebApi.Models.Lead;


public class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Suburb { get; set; }
    public DateTime? DateCreate { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}