using MediatR;
using PatientManagement.Core.CQRS.Room.Responses;

namespace PatientManagement.Core.CQRS.Room.Commands
{
    public record DeleteRoomCommand(int Id) : IRequest<RoomResponse>;
}
