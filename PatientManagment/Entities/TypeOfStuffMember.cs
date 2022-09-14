namespace PatientManagement.Core.Entities;
public class TypeOfStuffMember : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<StuffMember> StuffMembers { get; set; }
}
