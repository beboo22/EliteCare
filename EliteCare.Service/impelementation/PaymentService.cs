using EliteCare.Data.BaseResponse;
using EliteCare.Data.Entities;
using EliteCare.Data.ServiceAbstract;
using X.Paymob.CashIn;
using X.Paymob.CashIn.Models.Orders;
using X.Paymob.CashIn.Models.Payment;

namespace EliteCare.Service.impelementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymobCashInBroker _broker;

        public PaymentService(IPaymobCashInBroker broker)
        {
            _broker = broker;
        }
        public async Task<PaymentReturn> RequestCardPaymentKey(Bill bill)
        {
            // Create order.
            var amountCents = (int)Math.Round(bill.TotalAmount); // 10 LE
            var orderRequest = CashInCreateOrderRequest.CreateOrder(amountCents);
            var orderResponse = await _broker.CreateOrderAsync(orderRequest);

            // Request card payment key.
            var billingData = new CashInBillingData(
                firstName: bill.Patient.Fname, 
                lastName: $"{bill.Patient.Sname} {bill.Patient.Lname}",
                phoneNumber: bill.Patient.PhoneNumber,
                email: bill.Patient.Email);

            var paymentKeyRequest = new CashInPaymentKeyRequest(
                integrationId: 4947314, // change this
                orderId: orderResponse.Id, /// ----> should be bill id ????<----------
                billingData: billingData,
                amountCents: amountCents);

            var paymentKeyResponse = await _broker.RequestPaymentKeyAsync(paymentKeyRequest);

            // Create iframe src.
            return new PaymentReturn() { orederdId = orderResponse.Id , Token = _broker.CreateIframeSrc(iframeId: "898882", token: paymentKeyResponse.PaymentKey) };
        }
    }
    
}
