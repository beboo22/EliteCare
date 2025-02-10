using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class Bill:BaseEntity
    {
        public int AppointmentId { get; set; }
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public int? OdrederID { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string Notes { get; set; }
    }
}
