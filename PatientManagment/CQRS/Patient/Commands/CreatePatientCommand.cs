using Hospital.SharedKernel.Enums;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Responses;


namespace PatientManagement.Core.CQRS.Patient.Commands
{
    public record CreatePatientCommand(string FirstName, string LastName, int InsuranceNumber, string EmailAddress,Gender Gender, int PhoneNumber) : IRequest<PatientResponse>;
}
