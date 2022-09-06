namespace PatientManagement.Core.Entities
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}