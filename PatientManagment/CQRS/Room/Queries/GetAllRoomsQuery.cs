
using MediatR;
using PatientManagement.Core.CQRS.Room.Responses;

namespace PatientManagement.Core.CQRS.Room.Queries
{
    public record GetAllRoomsQuery : IRequest<IEnumerable<RoomResponse>>;
}
