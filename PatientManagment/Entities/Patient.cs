using Hospital.SharedKernel.Enums;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Entities;
public class Patient : BaseEntity
{
    public string FullName { get; set; }
    public int InsuranceNumber { get; set; }
    public string EmailAddress { get; set; }
    public int? PreferredDoctorId { get; set; }
    public Gender Gender { get; set; }
}
