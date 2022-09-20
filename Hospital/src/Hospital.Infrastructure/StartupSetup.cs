using FluentValidation;
using Hospital.Infrastructure.Data;
using Hospital.Infrastructure.Middleware;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Interfaces;
using PatientManagement.Core.Validators;
using PatientManagement.Core.Validators.Patient;
using PatientManagement.Data;

namespace Hospital.Infrastructure
{
  public static class StartupSetup
  {
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString)); // will be created in web project root

    public static void AddPatientManagement(this IServiceCollection services, IConfiguration configuration)
    {
      //todo find how to get calling assembly
      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
      services.AddAutoMapper(typeof(Patient).Assembly);
      services.AddMediatR(typeof(Patient).Assembly);
      services.AddValidatorsFromAssemblyContaining<CreatePatientCommandValidator>();
      services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));
      services.AddTransient<ExceptionHandlingMiddleware>();
      services.AddDbContext<PatientManagementContext>(options =>
        options.UseSqlServer(
          configuration.GetConnectionString("PatientManagement"),
          b => b.MigrationsAssembly(typeof(PatientManagementContext).Assembly.FullName)));
      
    }
  }
}
