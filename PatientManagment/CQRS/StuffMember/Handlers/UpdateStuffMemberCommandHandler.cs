using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Commands;
using PatientManagement.Core.CQRS.StuffMember.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.StuffMember.Handlers
{
    public class UpdateStuffMemberCommandHandler : IRequestHandler<UpdateStuffMemberCommand, StuffMemberResponse>
    {
        private readonly IGenericRepository<Entities.StuffMember> _stuffMemberRepository;
        private readonly IGenericRepository<Entities.Department> _departmentRepo;
        private readonly IGenericRepository<Entities.TypeOfStuffMember> _typeOfStuffMemberRepo;
        private readonly IMapper _mapper;

        public UpdateStuffMemberCommandHandler(IGenericRepository<Entities.StuffMember> repo,
            IMapper mapper, IGenericRepository<Entities.Department> departmentRepo,
            IGenericRepository<Entities.TypeOfStuffMember> typeOfStuffMemberRepo)
            
        {
            _mapper = mapper;
            _stuffMemberRepository = repo;
            _departmentRepo = departmentRepo;
            _typeOfStuffMemberRepo = typeOfStuffMemberRepo;
        }

        public async Task<StuffMemberResponse> Handle(UpdateStuffMemberCommand command, CancellationToken cancellationToken)
        {
            var stuffMemberToUpdate = _mapper.Map<Entities.StuffMember>(command);
            var department = await _departmentRepo.GetByIdAsync(command.DepartmentId);
            var typeOfStuffMember = await _typeOfStuffMemberRepo.GetByIdAsync(command.TypeOfStuffMemberId);
            stuffMemberToUpdate.Department = department;
            stuffMemberToUpdate.TypeOfStuffMember = typeOfStuffMember;
            var updatedStuffMember = await _stuffMemberRepository.UpdateAsync(stuffMemberToUpdate);
            return _mapper.Map<StuffMemberResponse>(updatedStuffMember);
        }
    }
}
