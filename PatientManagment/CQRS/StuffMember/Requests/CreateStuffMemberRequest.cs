
namespace PatientManagement.Core.CQRS.StuffMember.Requests
{
    public record CreateStuffMemberRequest(int DepartmentId, int TypeOfStuffMemberId, string FullName);
}
