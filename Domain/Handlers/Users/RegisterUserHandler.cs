using AutoMapper;
using MediatR;
using WebApi.Domain.Commands.Requests;
using WebApi.Interfaces;
using WebApi.Models.Users;

namespace WebApi.Domain.Handlers.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterRequest, CreateUserResponse>
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public Task<CreateUserResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var user = _userService.Register(request);
            return Task.FromResult(_mapper.Map<CreateUserResponse>(user));
        }
    }
}
