using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using PatientManagement.Core.Interfaces;
using PatientManagement.Core.Validators.Patient;

namespace PatientManagement.Core
{
    public static class StartupSetup
    {
        public static void AddPatientManagementCoreServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreatePatientCommandValidator>();
        }
    }
}
