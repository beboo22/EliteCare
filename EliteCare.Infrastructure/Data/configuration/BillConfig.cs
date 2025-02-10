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
    internal class BillConfig:BaseConfig<Bill>
    {
        public override void Configure(EntityTypeBuilder<Bill> builder)
        {
            base.Configure(builder);
            //builder.Property(x=>x.ID).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.TaxAmount).IsRequired().HasColumnType(SQlSyntax.Decimal);
            builder.Property(x => x.PaidAmount).IsRequired().HasColumnType(SQlSyntax.Decimal);
            builder.Property(x => x.BalanceAmount).IsRequired().HasColumnType(SQlSyntax.Decimal);
            builder.Property(x => x.Discount).IsRequired().HasColumnType(SQlSyntax.Decimal);
            builder.Property(x => x.TotalAmount).IsRequired().HasColumnType(SQlSyntax.Decimal);
            builder.Property(x => x.Notes).IsRequired().HasColumnType(SQlSyntax.NVarchar);

            builder.Property(p => p.PaymentStatus).IsRequired().HasConversion(s => s.ToString(),
                                                                       d => (PaymentStatus)Enum.Parse(typeof(PaymentStatus), d));
            builder.Property(p => p.PaymentMethod).IsRequired().HasConversion(s => s.ToString(),
                                                                       d => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), d));

            //builder.HasOne(p => p.Appointment)
            //       .WithOne(a => a.Bill)
            //       .HasForeignKey<Bill>(p => p.AppointmentId) // FK on Bill
            //       .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
