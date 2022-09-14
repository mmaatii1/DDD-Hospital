namespace PatientManagement.Core.Entities
{
    public class StuffMember : BaseEntity
    {
        public Department? Department { get; set; }
        public TypeOfStuffMember TypeOfStuffMember { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
