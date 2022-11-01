using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Responses;

namespace PatientManagement.Core.CQRS.StuffMember.Commands
{
    public record CreateStuffMemberCommand(int DepartmentId, int TypeOfStuffMemberId, string FirstName, string LastName) : IRequest<StuffMemberResponse>;
}
