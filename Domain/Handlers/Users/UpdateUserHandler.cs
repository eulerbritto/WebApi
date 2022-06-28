using MediatR;
using WebApi.Domain.Commands.Requests;
using WebApi.Interfaces;
using WebApi.Models.Users;

namespace WebApi.Domain.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateRequest, CreateUserResponse>
    {
        private IUserService _userService;
        public UpdateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<CreateUserResponse> Handle(UpdateRequest request, CancellationToken cancellationToken)
        {
            //veririca se conta já existe
            //valida dados
            //insere usuario
            //envia email informando criação
            var result = new CreateUserResponse
            {
                Id = 1,
                FirstName = "Novo",
                LastName = "Silva",
                Username = "_nsilva"
            };
            _userService.Update(request.Id, request);
            return Task.FromResult(result);
        }
    }
}
