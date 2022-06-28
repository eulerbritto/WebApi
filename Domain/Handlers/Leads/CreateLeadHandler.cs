using AutoMapper;
using MediatR;
using WebApi.Domain.Commands.Requests;
using WebApi.Domain.Commands.Requests.Leads;
using WebApi.Interfaces;
using WebApi.Models.Lead;

namespace WebApi.Domain.Handlers.Leads
{
    public class CreateLeadHandler : IRequestHandler<CreateLeadRequest, CreateLeadResponse>
    {
        private ILeadService _leadService;
        private readonly IMapper _mapper;
        public CreateLeadHandler(ILeadService leadService, IMapper mapper)
        {
            _leadService = leadService;
            _mapper = mapper;
        }
        public Task<CreateLeadResponse> Handle(CreateLeadRequest request, CancellationToken cancellationToken)
        {
            var lead = _leadService.Create(request);
            return Task.FromResult(_mapper.Map<CreateLeadResponse>(lead));
        }
    }
}
