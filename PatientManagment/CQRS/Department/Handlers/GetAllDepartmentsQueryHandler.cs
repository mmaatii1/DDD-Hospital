using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Department.Queries;
using PatientManagement.Core.CQRS.Department.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Department.Handlers
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentResponse>>
    {
        private readonly IGenericRepository<Entities.Department> _departmentRepository;
        private readonly IMapper _mapper;
        public GetAllDepartmentsQueryHandler(IGenericRepository<Entities.Department> repo, IMapper mapper)
        {
            _mapper = mapper;
            _departmentRepository = repo;
        }

        public async Task<IEnumerable<DepartmentResponse>> Handle(GetAllDepartmentsQuery request,
            CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentResponse>>(departments);
        }
    }
}
