using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    public class DeleteTypeOfStuffMemberCommandHandler : IRequestHandler<DeleteTypeOfStuffMemberCommand, TypeOfStuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IMapper _mapper;

        public DeleteTypeOfStuffMemberCommandHandler(IGenericRepository<Entities.TypeOfStuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _typeOfStuffMemberRepository = repo;
        }

        public async Task<TypeOfStuffMemberResponse> Handle(DeleteTypeOfStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var typeOfStuffMemberToDelete = await _typeOfStuffMemberRepository.DeleteAsync(command.Id);
            return _mapper.Map<TypeOfStuffMemberResponse>(typeOfStuffMemberToDelete);
        }
    }
}
