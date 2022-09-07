using AutoMapper;
using MediatR;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.CQRS.Patient.Responses;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.CQRS.Patient.Handlers
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientResponse>
    {
        private readonly IGenericRepository<Entities.Patient> _patientRepository;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IGenericRepository<Entities.Patient> repo, IMapper mapper)
        {
            _mapper = mapper;
            _patientRepository = repo;
        }

        public async Task<PatientResponse> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var patientToUpdate = _mapper.Map<Entities.Patient>(command);
            var updatedPatient = await _patientRepository.UpdateAsync(patientToUpdate);
            return _mapper.Map<PatientResponse>(updatedPatient);
        }
    }
}
