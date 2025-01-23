using EliteCare.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Data.configuration
{
    internal class PrescriptionConfig : BaseConfig<Prescription>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Prescription> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.PatientId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.DoctorId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.Property(x => x.FollowUpDate).IsRequired().HasColumnType(SQlSyntax.DateTime);
            builder.Property(x => x.Notes).HasMaxLength(int.MaxValue).HasColumnType(SQlSyntax.NVarchar);
            builder.Property(x => x.Diagnosis).HasMaxLength(int.MaxValue).HasColumnType(SQlSyntax.NVarchar);
        }
    }
}
