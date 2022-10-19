using MediatR;
using PatientManagement.Core.CQRS.TypeOfStuffMember.Responses;

namespace PatientManagement.Core.CQRS.TypeOfStuffMember.Queries
{
    public record GetTypeOfStuffMemberByIdQuery(int Id) : IRequest<TypeOfStuffMemberResponse>
    {
    }
}
