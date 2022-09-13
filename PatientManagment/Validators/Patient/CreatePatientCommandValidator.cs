﻿using FluentValidation;
using PatientManagement.Core.CQRS.Patient.Commands;

namespace PatientManagement.Core.Validators.Patient
{
    public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.InsuranceNumber)
                .GreaterThan(0);
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
    
}
