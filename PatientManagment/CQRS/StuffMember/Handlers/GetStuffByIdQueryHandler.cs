using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Queries;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.StuffMember.Handlers
{
    internal class GetStuffByIdQueryHandler : IRequestHandler<GetStuffMemberByIdQuery, StuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IMapper _mapper;
        public GetStuffByIdQueryHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
        }

        public async Task<StuffMemberResponse> Handle(GetStuffMemberByIdQuery request,
            CancellationToken cancellationToken)
        {
            var stuffMember = _stuffMemberRepository
                .GetWithEntity(x => x.Department, x => x.TypeOfStuffMember)
                .FirstOrDefault(c => c.Id == request.Id);

            return await Task.FromResult(_mapper.Map<StuffMemberResponse>(stuffMember));
        }
    }
}
