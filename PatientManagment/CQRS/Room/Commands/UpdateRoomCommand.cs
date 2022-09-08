using MediatR;
using PatientManagement.Core.CQRS.Room.Responses;

namespace PatientManagement.Core.CQRS.Room.Commands
{
    //updateCommands are classes in order to give access to set property without using constructor
    public class UpdateRoomCommand : IRequest<RoomResponse>
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}
