using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    public class UpdateTypeOfStuffMemberCommandHandler : IRequestHandler<UpdateStuffMemberCommand, StuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IMapper _mapper;

        public UpdateStuffMemberCommandHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
        }

        public async Task<StuffMemberResponse> Handle(UpdateStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var stuffMemberToUpdate = _mapper.Map<Entities.StuffMember>(command);
            var updatedtuffMembert = await _stuffMemberRepository.UpdateAsync(stuffMemberToUpdate);
            return _mapper.Map<StuffMemberResponse>(updatedDepartment);
        }
    }
}
