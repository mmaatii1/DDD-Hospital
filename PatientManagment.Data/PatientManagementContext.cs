using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;

namespace PatientManagement.Data
{
    public class PatientManagementContext : DbContext
    {
        public PatientManagementContext(DbContextOptions<PatientManagementContext> options) : base(options)
        {

        }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Department>? Department { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<TypeOfStuffMember>? TypesOfStuffMember { get; set; }
    }
}
