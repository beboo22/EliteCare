using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.enums
{
    public enum PaymentMethod
    {
        [EnumMember(Value = "Cash")]
        Cash,
        [EnumMember(Value = "CreditCard")]
        CreditCard,
        [EnumMember(Value = "DebitCard")]
        DebitCard,
        [EnumMember(Value = "Insurance")]
        Insurance,
        [EnumMember(Value = "BankTransfer")]
        BankTransfer,
        [EnumMember(Value = "MobilePayment")]
        MobilePayment
    }
}
