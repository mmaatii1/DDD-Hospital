using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Responses;

namespace PatientManagement.Core.CQRS.StuffMember.Commands
{
    public class UpdateStuffMemberCommand : IRequest<StuffMemberResponse>

    { 
        
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TypeOfStuffMemberId { get; set; }
        public string? FullName { get; set; }

    }

}
