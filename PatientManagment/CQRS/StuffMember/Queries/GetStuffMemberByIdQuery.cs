using MediatR;
using PatientManagement.Core.CQRS.StuffMember.Responses;

namespace PatientManagement.Core.CQRS.StuffMember.Queries
{
    public record GetStuffMemberByIdQuery(int Id) : IRequest<StuffMemberResponse>
    {
    }
}
