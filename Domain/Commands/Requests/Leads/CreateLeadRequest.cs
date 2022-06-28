using MediatR;
using System.ComponentModel.DataAnnotations;
using WebApi.Util.Enum;

namespace WebApi.Domain.Commands.Requests.Leads
{
    public class CreateLeadRequest : IRequest<CreateLeadResponse>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Suburb { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.UtcNow;
        [Required]
        [Display(ResourceType = typeof(Category))]
        public Category Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(ResourceType = typeof(Status))]
        public Status Status { get; set; }
    }
}
