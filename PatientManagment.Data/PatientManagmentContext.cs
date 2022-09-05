using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;

namespace PatientManagement.Data
{
    public class PatientManagmentContext : DbContext
    {
        public PatientManagmentContext() : base()
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TypeOfStuffMember> TypesOfStuffMember { get; set; }
    }
}
