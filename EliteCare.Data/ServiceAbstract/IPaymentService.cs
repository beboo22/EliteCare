using EliteCare.Data.BaseResponse;
using EliteCare.Data.Entities;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IPaymentService
    {
        Task<PaymentReturn> RequestCardPaymentKey(Bill bill);
    }
}
