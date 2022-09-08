
namespace PatientManagement.Core.CQRS.Room.Requests
{
    public record CreateRoomRequest(int RoomNumber, int DepartmentId);
}
