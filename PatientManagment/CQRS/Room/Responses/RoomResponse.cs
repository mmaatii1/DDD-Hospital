namespace PatientManagement.Core.CQRS.Room.Responses
{
    public record RoomResponse(int Id, int RoomNumber, int DepartmentId, string DepartmentName, string DepartmentDescription);
}
