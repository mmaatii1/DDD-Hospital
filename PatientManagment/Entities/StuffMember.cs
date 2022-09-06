namespace PatientManagement.Core.Entities
{
    public class StuffMember : BaseEntity
    {
        public int? DepartmentId { get; set; }
        public int TypeOfStuffMemberId { get; set; }
        public string FullName { get; set; }
    }
}
