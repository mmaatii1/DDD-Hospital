using FluentValidation;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Patient
{
    public class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientCommandValidator(IGenericRepository<Entities.Patient> repo)
        {
            RuleFor(x => x.Id)
                .IsEntityExist(repo, "Patient");
        }
    }
    
}
