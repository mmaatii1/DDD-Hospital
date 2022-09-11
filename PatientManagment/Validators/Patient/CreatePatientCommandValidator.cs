using FluentValidation;
using PatientManagement.Core.CQRS.Patient.Commands;

namespace PatientManagement.Core.Validators.Patient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty();
            RuleFor(x => x.InsuranceNumber)
                .GreaterThan(0);
        }
    }
    
}
