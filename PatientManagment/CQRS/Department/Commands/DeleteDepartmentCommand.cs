using MediatR;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department.Commands
{
    public record DeleteDepartmentCommand(int Id) : IRequest<DepartmentResponse>;

}
