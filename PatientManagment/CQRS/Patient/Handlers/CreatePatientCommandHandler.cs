using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Patient.Handlers
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientResponse>
    {
        private readonly IGenericRepository<Entities.Patient> _patientRepository;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IGenericRepository<Entities.Patient> repo, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repo;
        }

        public async Task<PatientResponse> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Entities.Patient>(command);
            var createdEntity = await _patientRepository.AddAsync(patient);
            return _mapper.Map<PatientResponse>(createdEntity);
        }
    }
}
