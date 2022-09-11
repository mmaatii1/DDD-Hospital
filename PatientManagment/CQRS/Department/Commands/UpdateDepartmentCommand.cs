using MediatR;
using PatientManagement.Core.CQRS.Department.Responses;

namespace PatientManagement.Core.CQRS.Department.Commands
{
    public class UpdateDepartmentCommand : IRequest<DepartmentResponse>

    {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    }

}
