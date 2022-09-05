namespace PatientManagement.Core.Entities
{
    public class Doctor : BaseEntity
    {
        public int DepartmentId { get; set; }
        public int TypeOfStuffMemberId { get; set; }
        public string FullName { get; set; }
    }
}
