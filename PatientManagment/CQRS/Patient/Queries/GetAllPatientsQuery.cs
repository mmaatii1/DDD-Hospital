using MediatR;
using PatientManagement.Core.CQRS.Patient.Responses;

namespace PatientManagement.Core.CQRS.Patient.Queries
{
    public record GetAllPatientsQuery : IRequest<IEnumerable<PatientResponse>>
    {
    }
}
