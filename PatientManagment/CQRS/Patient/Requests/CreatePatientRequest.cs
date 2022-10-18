using Hospital.SharedKernel.Enums;


namespace PatientManagement.Core.CQRS.Patient.Requests
{
    public record CreatePatientRequest(string FirstName, string LastName, int PhoneNumber, int InsuranceNumber, string EmailAddress, Gender Gender);

}
