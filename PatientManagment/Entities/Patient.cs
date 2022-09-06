using Hospital.SharedKernel.Enums;
namespace PatientManagement.Core.Entities;
public class Patient : BaseEntity
{
    public string FullName { get; set; }
    public int InsuranceNumber { get; set; }
    public string EmailAddress { get; set; }
    public Gender Gender { get; set; }
}
