using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.enums
{
    public enum PaymentStatus
    {
        [EnumMember(Value = "Pending")]
        Pending = 0,
        [EnumMember(Value = "Paid")]
        Paid,
        [EnumMember(Value = "PartiallyPaid")]
        PartiallyPaid,
        [EnumMember(Value = "Overdue")]
        Overdue,
        [EnumMember(Value = "Failed")]
        Failed,
        [EnumMember(Value = "Cancelled")]
        Cancelled
    }

}
