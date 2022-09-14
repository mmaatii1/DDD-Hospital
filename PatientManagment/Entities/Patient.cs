using Hospital.SharedKernel.Enums;
namespace PatientManagement.Core.Entities;
public class Patient : BaseEntity
{
    public string FullName { get; set; } = null!;
    public int InsuranceNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public Gender Gender { get; set; }
}
