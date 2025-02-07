using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using EliteCare.Service.specificationCriteria;

namespace EliteCare.Service.impelementation
{
    public class AppointmentService : IAppointmentService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> AddAppointment(Appointment appointment)
        {
            var DocRepo = _unitOfWork.Repo<Doctor>();
            var Check = await DocRepo.IsExist(appointment.DoctorID);
            if (!Check && appointment.Doctor.IsActive is false)
                return new ApiResponse(404, "There's no Doctor By this DoctorID OR Not Active");
            
            var PatientRepo = _unitOfWork.Repo<Patient>();
            Check = await PatientRepo.IsExist(appointment.PatientID);
            if (!Check && appointment.Patient.IsActive is false)
                return new ApiResponse(404, "There's no Patient By this PatientID OR Not Active");

            if (appointment.ReceptionistID.HasValue)
            {
                var ReceptionistRepo = _unitOfWork.Repo<Receptionist>();
                Check = await DocRepo.IsExist(appointment.ReceptionistID.Value);
                if (!Check && appointment.Receptionist.IsActive is false)
                    return new ApiResponse(404, "There's no Receptionist By this ReceptionistID OR Not Active");
            }
            
            var AppointRepo = _unitOfWork.Repo<Appointment>();
            Check = await AppointRepo.AddAsync(appointment);
            if (!Check)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Add Appointment");
        }

        public async Task<ApiResponse> DeleteAppointment(int id)
        {
            var AppointRepo = _unitOfWork.Repo<Appointment>();

            var appointment = await AppointRepo.GetByIdAsync(id);
            if (appointment is null) return new ApiResponse(404, "Appointment Not Found");

            var Check =  AppointRepo.Delete(appointment);
            if (!Check)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Delete Appointment");
        }
        public async Task<ApiResponse> UpdateAppointment(Appointment appointment)
        {

            var DocRepo = _unitOfWork.Repo<Doctor>();
            var Check = await DocRepo.IsExist(appointment.DoctorID);
            if (!Check && appointment.Doctor.IsActive is false)
                return new ApiResponse(404, "There's no Doctor By this DoctorID OR Not Active");

            var PatientRepo = _unitOfWork.Repo<Patient>();
            Check = await PatientRepo.IsExist(appointment.PatientID);
            if (!Check && appointment.Patient.IsActive is false)
                return new ApiResponse(404, "There's no Patient By this PatientID OR Not Active");

            
            if (appointment.ReceptionistID.HasValue)
            {
                var ReceptionistRepo = _unitOfWork.Repo<Receptionist>();
                Check = await ReceptionistRepo.IsExist(appointment.ReceptionistID.Value);
                if (!Check && appointment.Receptionist.IsActive is false)
                    return new ApiResponse(404, "There's no Receptionist By this ReceptionistID OR Not Active");
            }
            if (appointment.RoomID.HasValue)
            {
                var RoomRepo = _unitOfWork.Repo<Room>();
                Check = await RoomRepo.IsExist(appointment.RoomID.Value);
                if (!Check && appointment.Room.IsActive is false)
                    return new ApiResponse(404, "There's no Room By this RoomID OR Not Active");
            }
            if (appointment.PrescriptionID.HasValue)
            {
                var PrescriptionRepo = _unitOfWork.Repo<Prescription>();
                Check = await PrescriptionRepo.IsExist(appointment.PrescriptionID.Value);
                if (!Check && appointment.prescription.IsActive is false)
                    return new ApiResponse(404, "There's no Prescription By this PrescriptionID OR Not Active");
            }
            if (appointment.BillID.HasValue)
            {
                var BillRepo = _unitOfWork.Repo<Bill>();
                Check = await BillRepo.IsExist(appointment.BillID.Value);
                if (!Check && appointment.Bill.IsActive is false)
                    return new ApiResponse(404, "There's no Bill By this BillID OR Not Active");
            }

            var AppointRepo = _unitOfWork.Repo<Appointment>();
            appointment.UpdatedAt = DateTime.Now;
            Check = AppointRepo.Update(appointment);
            if (!Check)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while update Appointment");
        }

        public Task<IEnumerable<Appointment>> GetAppointment()
        {
            var AppointSpec = new AppointmentSpecification(null);
            var AppointRepo = _unitOfWork.Repo<Appointment>();
            var AllAppointment = AppointRepo.GetBySpecification(AppointSpec);
            return AllAppointment;
        }

        public Task<Appointment> GetAppointmentById(int id)
        {
            var AppointSpec = new AppointmentSpecification(id);
            var AppointRepo = _unitOfWork.Repo<Appointment>();
            var AllAppointment = AppointRepo.GetByIDSpecification(AppointSpec);
            return AllAppointment;
        }

    }
}
