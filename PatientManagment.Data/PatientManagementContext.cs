using Hospital.SharedKernel.Enums;
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
        public DbSet<StuffMember>? Doctors { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<TypeOfStuffMember>? TypesOfStuffMember { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Description = "Department where the surgeries are carried out",
                Name = "Surgeon",
                Id = 1,
            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = 1,
                FullName = "Majkel Reszka",
                EmailAddress = "majkelreszka@gmail.com",
                Gender = Gender.Male,
                InsuranceNumber = 12353123,
            });
            modelBuilder.Entity<Room>().HasData(new Room
            {
                Id = 1,
                DepartmentId = 1,
                RoomNumber = 10,
            });
            modelBuilder.Entity<TypeOfStuffMember>().HasData(new TypeOfStuffMember
            {
                Id = 1,
                Description = "Doctors which are qualified to do surgery",
                Name = "Surgeons",
            });
            modelBuilder.Entity<StuffMember>().HasData(new StuffMember
            {
                Id = 1,
                FullName = "Kamil Ollik",
                DepartmentId = 1,
                TypeOfStuffMemberId = 1
            });
        }
    }
}
