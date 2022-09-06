using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PatientManagement.Data
{
    public static class ServiceExtension
    {
        public static void AddPatientManagementData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PatientManagementContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("PatientManagement"),
                    b => b.MigrationsAssembly(typeof(PatientManagementContext).Assembly.FullName)));
        }
    }
}
