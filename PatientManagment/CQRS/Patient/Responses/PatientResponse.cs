using Hospital.SharedKernel.Enums;

namespace PatientManagement.Core.CQRS.Patient.Responses
{
    public record PatientResponse(int Id, string FullName, int InsuranceNumber, string EmailAddress, Gender Gender);
}
