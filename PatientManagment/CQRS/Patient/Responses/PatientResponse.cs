using Hospital.SharedKernel.Enums;

namespace PatientManagement.Core.CQRS.Patient.Responses
{
    public record PatientResponse(int Id, string FirstName, string LastName, int PhoneNumber, int InsuranceNumber, string EmailAddress, Gender Gender);
}
