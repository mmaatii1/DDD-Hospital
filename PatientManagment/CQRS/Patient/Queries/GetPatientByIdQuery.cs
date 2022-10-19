using MediatR;
using PatientManagement.Core.CQRS.Patient.Responses;

namespace PatientManagement.Core.CQRS.Patient.Queries
{
    public record GetPatientByIdQuery(int Id) : IRequest<PatientResponse>
    {
    }
}
