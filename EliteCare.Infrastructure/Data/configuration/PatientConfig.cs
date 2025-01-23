using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Data.configuration
{
    internal class PatientConfig : BaseConfig<Patient>  
    {
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);


            builder.Property(x => x.Fname).IsRequired().HasMaxLength(100).HasColumnType(SQlSyntax.Varchar);
            builder.Property(x => x.Lname).IsRequired().HasMaxLength(100).HasColumnType(SQlSyntax.Varchar);
            builder.Property(p => p.Gender).IsRequired().HasConversion(s => s.ToString(),
                                                                       d => (Gender)Enum.Parse(typeof(Gender), d));
            //builder.Property(p => p.Address).HasMaxLength(255);
            builder.Property(p => p.PhoneNumber).HasMaxLength(15).HasColumnType(SQlSyntax.NVarchar);
            builder.Property(p => p.Email).HasMaxLength(int.MaxValue).HasColumnType(SQlSyntax.NVarchar);
            builder.Property(p => p.EmergencyContact).HasMaxLength(int.MaxValue).HasColumnType(SQlSyntax.NVarchar);
            builder.Property(p => p.MedicalHistory).HasMaxLength(int.MaxValue).HasColumnType(SQlSyntax.NVarchar);
            builder.Property(p => p.DateOfBirth).IsRequired().HasColumnType(SQlSyntax.DateTime);
        }
    }
}
