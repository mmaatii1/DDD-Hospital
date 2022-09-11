using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.StuffMember.Handlers
{
    public class CreateStuffMemberCommandHandler : IRequestHandler<CreateStuffMemberCommand, StuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IMapper _mapper;

        public CreateStuffMemberCommandHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
        }

        public async Task<StuffMemberResponse> Handle(CreateStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var stuffMember = _mapper.Map<Entities.StuffMember>(command);
            var createdEntity = await _stuffMemberRepository.AddAsync(stuffMember);
            return _mapper.Map<StuffMemberResponse>(createdEntity);
        }
    }
}
