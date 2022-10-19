using Hospital.SharedKernel.Enums;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Responses;

namespace PatientManagement.Core.CQRS.Patient.Commands
{
    public class UpdatePatientCommand : IRequest<PatientResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public int InsuranceNumber { get; set; }
        public string EmailAddress { get; set; } = null!;
        public Gender Gender { get; set; }
    }
}
