
namespace PatientManagement.Core.CQRS.StuffMember.Responses
{
    public record StuffMemberResponse(int Id, int DepartmentId, string DepartmentName, string DepartmentDescription, int TypeOfStuffMemberId, string TypeOfStuffMemberName, string TypeOfStuffMemberDescription, string FullName);


}
