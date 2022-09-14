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
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepository;
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;

        public CreateStuffMemberCommandHandler(IGenericRepository<Entities.StuffMember> repo, IMapper mapper, IGenericRepository<Entities.Department> departmentRepository, IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepository)
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
            _departmentRepository = departmentRepository;
            _typeOfStuffMemberRepository = typeOfStuffMemberRepository;
        }

        public async Task<StuffMemberResponse> Handle(CreateStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(command.DepartmentId);
            var typeOfStuffMember = await _typeOfStuffMemberRepository.GetByIdAsync(command.TypeOfStuffMemberId);
            var stuffMember = _mapper.Map<Entities.StuffMember>(command);
            stuffMember.Department = department;
            stuffMember.TypeOfStuffMember = typeOfStuffMember;
            var createdEntity = await _stuffMemberRepository.AddAsync(stuffMember);
            return _mapper.Map<StuffMemberResponse>(createdEntity);
        }
    }
}
