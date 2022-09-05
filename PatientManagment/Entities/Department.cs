namespace PatientManagement.Core.Entities;
public class Department : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Room> Rooms { get; set; }
}
