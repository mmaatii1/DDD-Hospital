using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.CQRS.Department.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Department.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DepartmentResponse>
    {
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IGenericRepository<Entities.Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = repo;
        }

        public async Task<DepartmentResponse> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            var departmentToDelete = await _departmentRepository.DeleteAsync(command.Id);
            return _mapper.Map<DepartmentResponse>(departmentToDelete);
        }
    }
}
