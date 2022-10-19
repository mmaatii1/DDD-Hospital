using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Queries;
using PatientManagement.Core.CQRS.Patient.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Patient.Handlers
{
    public class GetByIdPatientCommandHandler : IRequestHandler<GetPatientByIdQuery, PatientResponse>
    {
        private readonly IGenericRepository<Entities.Patient> _patientRepository;
        private readonly IMapper _mapper;
        public GetByIdPatientCommandHandler(IGenericRepository<Entities.Patient> repo, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repo;
        }

        public async Task<PatientResponse> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetByIdAsync(request.Id);
            return _mapper.Map<PatientResponse>(patients);
        }
    }
}
