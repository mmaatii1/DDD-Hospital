using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Department.Queries;
using PatientManagement.Core.CQRS.Department.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Department.Handlers
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentResponse>
    {
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;
        public GetDepartmentByIdQueryHandler(IGenericRepository<Entities.Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = repo;
        }

        public async Task<DepartmentResponse> Handle(GetDepartmentByIdQuery request,
            CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetByIdAsync(request.Id);
            return _mapper.Map<DepartmentResponse>(departments);
        }
    }
}
