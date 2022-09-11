using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Queries;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    public class GetAllTypesOfStuffMemberQueryHandler : IRequestHandler<GetAllTypesOfStuffMembersQuery, IEnumerable<TypeOfStuffMemberResponse>>
    {
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IMapper _mapper;
        public GetAllTypesOfStuffMemberQueryHandler(IGenericRepository<Entities.TypeOfStuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _typeOfStuffMemberRepository = repo;
        }

        public async Task<IEnumerable<TypeOfStuffMemberResponse>> Handle(GetAllTypesOfStuffMembersQuery request,
            CancellationToken cancellationToken)
        {
            var typeOfStuffMember = await _typeOfStuffMemberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TypeOfStuffMemberResponse>>(typeOfStuffMember);
        }
    }
}
