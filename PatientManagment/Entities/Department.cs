namespace PatientManagement.Core.Entities;
public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Room> Rooms { get; set; }    
    public ICollection<StuffMember> StuffMembers { get; set; }
}
