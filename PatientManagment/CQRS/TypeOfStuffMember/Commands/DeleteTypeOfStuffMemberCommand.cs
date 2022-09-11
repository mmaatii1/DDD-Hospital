using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Commands
{
    public record DeleteTypeOfStuffMemberCommand(int Id) : IRequest<TypeOfStuffMemberResponse>;

}
