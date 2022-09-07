using MediatR;
using PatientManagement.Core.CQRS.Patient.Responses;

namespace PatientManagement.Core.CQRS.Patient.Commands
{
    public record DeletePatientCommand(int Id) : IRequest<PatientResponse>;
}
