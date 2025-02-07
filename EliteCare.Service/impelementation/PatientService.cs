using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using EliteCare.Infrastructure.Repository.impelementation;
using EliteCare.Service.specificationCriteria;

namespace EliteCare.Service.impelementation
{
    public class PatientService : IPatientService
    {
        IUnitOfWork unitOfWork;
        IPatientRepo PatientRepo;
        IAddressRepo _addressRepo { get; set; }

        public PatientService(IPatientRepo receptionistRepo, IUnitOfWork unitOfWork, IAddressRepo addressRepo)
        {
            this.PatientRepo = receptionistRepo;
            this.unitOfWork = unitOfWork;
            _addressRepo = addressRepo;
        }

        public async Task<ApiResponse> AddPatientAsync(Patient Patient, Address address)
        {
            var flag = await _addressRepo.AddAddressAsync(address);

            if (!flag) return new ApiResponse(500, "Error while Adding, Can't Add Address");
            int check = await unitOfWork.Commit();
            if (check < 0) return new ApiResponse(500, $"Error While Saving Changing AddessID{address.Id}");
            Patient.AddressId = address.Id;

            flag = await PatientRepo.AddAsync(Patient);
            if (flag)
            {
                check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Adding");
        }

        public async Task<ApiResponse> DeletePatientAsync(int id)
        {
            var recep = await PatientRepo.GetByIdAsync(id);
            if (recep is null)
            {
                return new ApiResponse(404, "Receptionist Don't Existing");
            }

            if (recep.AddressId != 0)
            {
                var add = await _addressRepo.GetAddress(recep.AddressId);
                if (add is not null)
                {
                    var check = _addressRepo.DeleteAddress(add);
                    if (!check) return new ApiResponse(500, "Error While delating and Can't Delete Address");
                }
                return new ApiResponse(404, "Address Not Found");
            }
            var flag = PatientRepo.Delete(recep);
            if (flag)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Deleting Patient");

        }

        public async Task<IEnumerable<Patient>> GetAllPatient()
        {
            var RecepistSpec = new PatientSpecification(null, null);
            var AllRecepist = await PatientRepo.GetBySpecification(RecepistSpec);

            return AllRecepist;
        }

        public async Task<IEnumerable<Appointment>?> GetAppointmentsForPatient(int PatientId)
        {
            var receptionistExist = await PatientRepo.IsExist(PatientId);

            if (!receptionistExist)
                return null;

            var appointments = await PatientRepo.GetAppointmentsForPatient(PatientId);
            return appointments;
        }

        public async Task<Patient> GetPatientByEmail(string email)
        {
            string Email = email;
            var spec = new PatientSpecification(Email, null);
            var Recepist = (await PatientRepo.GetBySpecification(spec)).FirstOrDefault();
            return Recepist;
        }

        public async Task<Patient> GetPatientByIdSpec(int id)
        {
            var RecepistSpec = new PatientSpecification(null, id);
            var Recepist = await PatientRepo.GetByIDSpecification(RecepistSpec);

            return Recepist;
        }

        public async Task<ApiResponse> UpdatePatientAsync(Patient Patient, Address address)
        {
            var recept = await PatientRepo.GetByIdAsync(Patient.ID);

            if (recept is null)
            {
                return new ApiResponse(404, "Patient Don't Existing");
            }
            if (address is not null)
            {
                address.Id = Patient.AddressId;
                var check = _addressRepo.UpdateAddress(address);
                if (!check) return new ApiResponse(500, "Error While Updating and The Reason is Address");

                Patient.Address = address;
                Patient.AddressId = address.Id;
            }

            bool flag = PatientRepo.Update(Patient);
            if (flag)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Update Patient");

        }
    }
}
