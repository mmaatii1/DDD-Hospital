using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Queries;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Handlers
{
    public class GetTypeOfStuffMemberByIdQueryHandler : IRequestHandler<GetTypeOfStuffMemberByIdQuery, TypeOfStuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IMapper _mapper;
        public GetTypeOfStuffMemberByIdQueryHandler(IGenericRepository<Entities.TypeOfStuffMember> repo, IMapper mapper)
        {
            _mapper = mapper;
            _typeOfStuffMemberRepository = repo;
        }

        public async Task<TypeOfStuffMemberResponse> Handle(GetTypeOfStuffMemberByIdQuery request,
            CancellationToken cancellationToken)
        {
            var typeOfStuffMember = await _typeOfStuffMemberRepository.GetByIdAsync(request.Id);

            return _mapper.Map<TypeOfStuffMemberResponse>(typeOfStuffMember);
        }
    }
}
