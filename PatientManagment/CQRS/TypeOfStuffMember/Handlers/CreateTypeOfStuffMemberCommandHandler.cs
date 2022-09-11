using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Commands;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    public class CreateTypeOfStuffMemberCommandHandler : IRequestHandler<CreateTypeOfStuffMemberCommand, TypeOfStuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IMapper _mapper;

        public CreateTypeOfStuffMemberCommandHandler(IGenericRepository<Entities.TypeOfStuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _typeOfStuffMemberRepository = repo;
        }

        public async Task<TypeOfStuffMemberResponse> Handle(CreateTypeOfStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var typeOfStuffMember = _mapper.Map<Entities.TypeOfStuffMember>(command);
            var createdEntity = await _typeOfStuffMemberRepository.AddAsync(typeOfStuffMember);
            return _mapper.Map<TypeOfStuffMemberResponse>(createdEntity);
        }
    }
}
