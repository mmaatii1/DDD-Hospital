using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Commands
{
    public record CreateTypeOfStuffMemberCommand(string Name, string Description) : IRequest<TypeOfStuffMemberResponse>;
}
