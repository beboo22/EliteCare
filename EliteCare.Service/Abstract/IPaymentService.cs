using EliteCare.Data.Entities;
using EliteCare.Service.impelementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IPaymentService
    {
        Task<PaymentReturn> RequestCardPaymentKey(Bill bill);
    }
}
