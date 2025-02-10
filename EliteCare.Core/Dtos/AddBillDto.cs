using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class AddBillDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public DateTime BillDate { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Notes { get; set; }
    }
}
