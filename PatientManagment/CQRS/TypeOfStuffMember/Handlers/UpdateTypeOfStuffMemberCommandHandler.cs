using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    internal class UpdateTypeOfStuffMemberCommandHandler : IRequestHandler<UpdateTypeOfStuffMemberCommand, TypeOfStuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IMapper _mapper;

        public UpdateTypeOfStuffMemberCommandHandler(IGenericRepository<Entities.TypeOfStuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _typeOfStuffMemberRepository = repo;
        }

        public async Task<TypeOfStuffMemberResponse> Handle(UpdateTypeOfStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var typeOfStuffMemberToUpdate = _mapper.Map<Entities.TypeOfStuffMember>(command);
            var updatedStuffMember = await _typeOfStuffMemberRepository.UpdateAsync(typeOfStuffMemberToUpdate);
            return _mapper.Map<TypeOfStuffMemberResponse>(updatedStuffMember);
        }
    }
}
