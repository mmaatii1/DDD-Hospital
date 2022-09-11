using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.StuffMember.Handlers
{
    public class DeleteStuffMemberCommandHandler : IRequestHandler<DeleteStuffMemberCommand, StuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IMapper _mapper;

        public DeleteStuffMemberCommandHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
        }

        public async Task<StuffMemberResponse> Handle(DeleteStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var stuffMemberToDelete = await _stuffMemberRepository.DeleteAsync(command.Id);
            return _mapper.Map<StuffMemberResponse>(stuffMemberToDelete);
        }
    }
}
