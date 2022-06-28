using System.Text.Json.Serialization;

namespace WebApi.Domain.Commands.Requests
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
