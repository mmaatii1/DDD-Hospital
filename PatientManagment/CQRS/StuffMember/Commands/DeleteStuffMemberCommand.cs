using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Responses;

namespace PatientManagement.Core.CQRS.StuffMember.Commands
{
    public record DeleteStuffMemberCommand(int Id) : IRequest<StuffMemberResponse>;

}
