using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Queries;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.StuffMember.Handlers
{
    public class GetAllStuffMembersQueryHandler : IRequestHandler<GetAllStuffMembersQuery, IEnumerable<StuffMemberResponse>>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IMapper _mapper;
        public GetAllStuffMembersQueryHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
        }

        public async Task<IEnumerable<StuffMemberResponse>> Handle(GetAllStuffMembersQuery request,
            CancellationToken cancellationToken)
        {
            var stuffMember = await _stuffMemberRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StuffMemberResponse>>(stuffMember);
        }
    }
}
