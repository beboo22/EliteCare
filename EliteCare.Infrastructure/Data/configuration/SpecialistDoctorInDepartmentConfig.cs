using EliteCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Data.configuration
{
    internal class SpecialistDoctorInDepartmentConfig : IEntityTypeConfiguration<SpecialistDoctorInDepartment>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SpecialistDoctorInDepartment> builder)
        {
            builder.HasKey(x =>  x.DoctorId);
            builder.Property(s=>s.DoctorId).IsRequired().ValueGeneratedNever();
            builder.HasOne(x => x.Doctor)
                .WithOne(x => x.SpecialistDoctorInDepartment)
                .HasForeignKey<SpecialistDoctorInDepartment>(x => x.DoctorId)
                .OnDelete(deleteBehavior:DeleteBehavior.NoAction);
            builder.HasOne(x => x.Department)
                .WithOne(x => x.SpecialistDoctorInDepartment)
                .HasForeignKey<SpecialistDoctorInDepartment>(x => x.DepartmentId)
                .OnDelete(deleteBehavior:DeleteBehavior.NoAction);
        }
    }
}
