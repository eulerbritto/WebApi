using WebApi.Util.Enum;

namespace WebApi.Domain.Commands.Requests
{
    public class CreateLeadResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
