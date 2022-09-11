using MediatR;
using PatientManagement.Core.CQRS.Room.Responses;

namespace PatientManagement.Core.CQRS.Room.Commands
{
    public record CreateRoomCommand(int RoomNumber, int DepartmentId) : IRequest<RoomResponse>;
}
