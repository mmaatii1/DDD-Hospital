using Hospital.SharedKernel.Enums;


namespace PatientManagement.Core.CQRS.Patient.Requests
{
    public record CreatePatientRequest(string FullName, int InsuranceNumber, string EmailAddress, Gender Gender);

}
