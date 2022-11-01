
namespace PatientManagement.Core.CQRS.StuffMember.Requests
{
    public record UpdateStuffMemberRequest(int DepartmentId, int TypeOfStuffMemberId, string FirstName, string LastName);
  
}
