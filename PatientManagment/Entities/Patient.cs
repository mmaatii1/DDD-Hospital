using Hospital.SharedKernel.Enums;
namespace PatientManagement.Core.Entities;
public class Patient : BaseEntity
{
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public int InsuranceNumber { get; set; }
    public string EmailAddress { get; set; } = null!;
    public Gender Gender { get; set; }
    public int PhoneNumber { get; set; }
}
