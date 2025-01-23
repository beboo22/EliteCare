using EliteCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EliteCare.Infrastructure.Data.configuration
{
    internal class AppointmentConfig : BaseConfig<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Room).WithOne().HasForeignKey<Appointment>(x => x.RoomId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Receptionist).WithOne().HasForeignKey<Appointment>(x => x.ReceptionistId).OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
