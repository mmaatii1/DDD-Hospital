
using MediatR;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department.Commands
{
    public record CreateDepartmentCommand(string Name, string Description) : IRequest<DepartmentResponse>;
}
