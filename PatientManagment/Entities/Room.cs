namespace PatientManagement.Core.Entities
{
    public class Room : BaseEntity
    {
        public int RoomNumber { get; set; }
        public Department Department { get; set; } = null!;
    }
}