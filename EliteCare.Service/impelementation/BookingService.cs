using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class BookingService : IBookingService
    {

        IUnitOfWork _unitOfWork { get; set; }
        IBillRepo _billRepo { get; set; }
        IPaymentService paymentService { get; set; }

        public BookingService(IUnitOfWork unitOfWork, IPaymentService paymentService, IBillRepo billRepo)
        {
            _unitOfWork = unitOfWork;
            this.paymentService = paymentService;
            _billRepo = billRepo;
        }

        public async Task<ApiResponse> Book(Bill bill)
        {
            var AppointmentRepo = _unitOfWork.Repo<Appointment>();


            var check = await AppointmentRepo.IsExist(bill.AppointmentId);
            if (!check)
                return new ApiResponse(404, "There's no appointment by this AppointmentId");


            var PatientRepo = _unitOfWork.Repo<Patient>();

            var patient = await PatientRepo.GetByIdAsync(bill.PatientId);
            if (patient is null)
                return new ApiResponse(404, "There's no Patient by this PatientId");



            decimal subtotal = bill.PaidAmount + bill.BalanceAmount;
            decimal discountedAmount = subtotal - bill.Discount;
            bill.TotalAmount = discountedAmount + bill.TaxAmount;
            bill.PaymentStatus = PaymentStatus.Pending;

            bill.Patient = patient;

            var paymentUrl = await paymentService.RequestCardPaymentKey(bill);


            bill.OdrederID = paymentUrl.orederdId;

            bill.Patient = null;
            var billRepo = _unitOfWork.Repo<Bill>();
            check = await billRepo.AddAsync(bill);
            if (!check)
            {
                return new ApiResponse(500, "Error while Adding");
            }

            int flag = await _unitOfWork.Commit();
            if (flag < 0) return new ApiResponse(500, "Error While Saving Changing");

            var CheckUpdateAppointmentID = await UpdateBillIDForAppointment(bill.ID, bill.AppointmentId);
            

            return new ApiResponse(CheckUpdateAppointmentID.statusCode, $"{CheckUpdateAppointmentID.message}\nPayment URL generated successfully{new { PaymentUrl = paymentUrl.Token }}");

        }
        private async Task<ApiResponse> UpdateBillIDForAppointment(int appointmentID, int BillID)
        {
            var AppointmentRep = _unitOfWork.Repo<Appointment>();

            var appointment = await AppointmentRep.GetByIdAsync(appointmentID);

            appointment.BillID = BillID;

            var check = AppointmentRep.Update(appointment);
            if (!check)
            {
                return new ApiResponse(500, "Error will Update BillId in Appointment Table");
            }
            return new ApiResponse(200);
        }

        public async Task<ApiResponse> HandlePaymobCallback(JsonElement payload)
        {
            // Extract data from Paymob callback payload
            var success = payload.GetProperty("success").GetBoolean();
            var orderId = payload.GetProperty("order").GetInt32();
            var amountCents = payload.GetProperty("amount_cents").GetInt32();
            var paymentMethod = payload.GetProperty("source_data").GetProperty("type").GetString();

            // Find the bill by orderId (assuming orderId maps to BillId)
            var bill =  _billRepo.GetByOrderddId(orderId);

            if (bill == null)
            {
                return new ApiResponse(404, "Bill not found");
            }

            // Update bill payment status and method
            bill.PaymentStatus = success ? PaymentStatus.Paid : PaymentStatus.Failed;
            bill.PaymentMethod = paymentMethod switch
            {
                "card" => PaymentMethod.CreditCard,
                "wallet" => PaymentMethod.MobilePayment,
                _ => PaymentMethod.CreditCard // Default to CreditCard
            };

            // Save changes to the database
            await _unitOfWork.Commit();

            return new ApiResponse(200, "Callback handled successfully");
        }


    }
}
