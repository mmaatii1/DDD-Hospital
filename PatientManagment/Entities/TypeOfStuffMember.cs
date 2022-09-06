namespace PatientManagement.Core.Entities;
public class TypeOfStuffMember : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<StuffMember> StuffMembers { get; set; }
}
