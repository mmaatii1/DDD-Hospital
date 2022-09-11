using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Commands
{
    public class UpdateTypeOfStuffMemberCommand : IRequest<TypeOfStuffMemberResponse>

    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

}
