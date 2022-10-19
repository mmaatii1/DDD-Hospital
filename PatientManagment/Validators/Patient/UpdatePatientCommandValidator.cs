using FluentValidation;
using PatientManagement.Core.CQRS.Patient.Commands;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Core.Validators.Patient
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator(IGenericRepository<Entities.Patient> repo)
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.InsuranceNumber)
                .GreaterThan(0);
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
        }
    }
}
