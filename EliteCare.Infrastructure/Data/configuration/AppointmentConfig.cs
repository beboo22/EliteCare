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
            builder.HasOne(x => x.Doctor)
               .WithMany()
               .HasForeignKey(x => x.DoctorID)
               .HasConstraintName("FK_Appointment_Doctor")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Patient)
                   .WithMany()
                   .HasForeignKey(x => x.PatientID)
                   .HasConstraintName("FK_Appointment_Patient")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Receptionist)
                   .WithMany()
                   .HasForeignKey(x => x.ReceptionistID)
                   .HasConstraintName("FK_Appointment_Receptionist")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Room)
                   .WithMany()
                   .HasForeignKey(x => x.RoomID)
                   .HasConstraintName("FK_Appointment_Room")
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
