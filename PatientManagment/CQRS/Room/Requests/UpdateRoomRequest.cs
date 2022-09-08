
namespace PatientManagement.Core.CQRS.Room.Requests
{
    public record UpdateRoomRequest(int RoomNumber, int DepartmentId);
}
