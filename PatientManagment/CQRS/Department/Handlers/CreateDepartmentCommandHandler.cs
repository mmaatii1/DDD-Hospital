using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.CQRS.Department.Responses;
using PatientManagement.Core.Interfaces;


namespace PatientManagement.Core.CQRS.Department.Handlers
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentResponse>
    {
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IGenericRepository<Entities.Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = repo;
        }

        public async Task<DepartmentResponse> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Entities.Department>(command);
            var createdEntity = await _departmentRepository.AddAsync(department);
            return _mapper.Map<DepartmentResponse>(createdEntity);
        }
    }
}
