using MediatR;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department.Queries
{
    public record GetDepartmentByIdQuery(int Id) : IRequest<DepartmentResponse>
    {
    }
}
