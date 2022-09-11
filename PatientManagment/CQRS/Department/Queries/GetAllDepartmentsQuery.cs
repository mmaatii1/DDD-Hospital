using MediatR;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department.Queries
{
    public record GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentResponse>>;

}
