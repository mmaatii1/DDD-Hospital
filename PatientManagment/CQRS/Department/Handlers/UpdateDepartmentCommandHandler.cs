using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Department.Commands;
using PatientManagement.Core.CQRS.Department.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Department.Handlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentResponse>
    {
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IGenericRepository<Entities.Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = repo;
        }

        public async Task<DepartmentResponse> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            var departmentToUpdate = _mapper.Map<Entities.Department>(command);
            var updatedDepartment = await _departmentRepository.UpdateAsync(departmentToUpdate);
            return _mapper.Map<DepartmentResponse>(updatedDepartment);
        }
    }
}
