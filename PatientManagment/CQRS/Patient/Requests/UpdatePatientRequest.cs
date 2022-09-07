using Hospital.SharedKernel.Enums;

namespace PatientManagement.Core.CQRS.Patient.Requests
{
    public record UpdatePatientRequest(string FullName, int InsuranceNumber, string EmailAddress,
        Gender Gender);
}
