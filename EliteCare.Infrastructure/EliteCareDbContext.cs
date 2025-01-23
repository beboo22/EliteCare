using EliteCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EliteCare.Infrastructure
{
    public class EliteCareDbContext : DbContext
    {
        public EliteCareDbContext(DbContextOptions<EliteCareDbContext> options) : base(options) { }
        #region property
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Bill> Bills { get; set; }


        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
