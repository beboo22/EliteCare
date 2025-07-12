using EliteCare.Data;
using EliteCare.Data.Abstract;
using EliteCare.Data.Entities;
using EliteCare.Data.ServiceAbstract;
using EliteCare.Service.BaseResponse;
using EliteCare.Service.specificationCriteria;

namespace EliteCare.Service.impelementation
{
    public class ReceptionistService : IReceptionistService
    {

        IUnitOfWork unitOfWork;
        IReceptionistRepo receptionistRepo;
        IAddressRepo _addressRepo { get; set; }

        public ReceptionistService(IReceptionistRepo receptionistRepo, IUnitOfWork unitOfWork, IAddressRepo addressRepo)
        {
            this.receptionistRepo = receptionistRepo;
            this.unitOfWork = unitOfWork;
            _addressRepo = addressRepo;
        }
        public async Task<ApiResponse> AddReceptionistAsync(Receptionist Receptionist, Address address)
        {


            var flag = await _addressRepo.AddAddressAsync(address);

            if (!flag) return new ApiResponse(500, "Error while Adding, Can't Add Address");
            int check = await unitOfWork.Commit();
            if (check < 0) return new ApiResponse(500, $"Error While Saving Changing AddessID{address.Id}");


            Receptionist.AddressId = address.Id;

            flag = await receptionistRepo.AddAsync(Receptionist);
            if (flag)
            {
                check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Adding");
        }

        public async Task<ApiResponse> UpdateReceptionistAsync(Receptionist Receptionist, Address address)
        {
            var recept = await receptionistRepo.GetByIdAsync(Receptionist.ID);

            if (recept is null)
            {
                return new ApiResponse(404, "Receptionist Don't Existing");
            }
            if (address is not null)
            {
                address.Id = Receptionist.AddressId;
                var check = _addressRepo.UpdateAddress(address);
                if (!check) return new ApiResponse(500, "Error While Updating and The Reason is Address");

                Receptionist.Address = address;
                Receptionist.AddressId = address.Id;
            }
            
            bool flag = receptionistRepo.Update(Receptionist);
            if (flag)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Update Receptionist");
        }
        public async Task<ApiResponse> DeleteReceptionistAsync(int id)
        {
            var recep = await receptionistRepo.GetByIdAsync(id);
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
            var flag = receptionistRepo.Delete(recep);
            if (flag)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Deleting Receptionist");
        }

        public async Task<IEnumerable<Receptionist>> GetAllReceptionist()
        {
            var RecepistSpec = new ReceptionistSpecification(null, null);
            var AllRecepist = await receptionistRepo.GetBySpecification(RecepistSpec);

            return AllRecepist;
        }

        public async Task<Receptionist> GetReceptionistByEmail(string email)
        {
            string Email = email;
            var spec = new ReceptionistSpecification(Email, null);
            var Recepist = (await receptionistRepo.GetBySpecification(spec)).FirstOrDefault();
            return Recepist;
        }

        public async Task<Receptionist> GetReceptionistByIdSpec(int id)
        {
            var RecepistSpec = new ReceptionistSpecification(null, id);
            var Recepist = await receptionistRepo.GetByIDSpecification(RecepistSpec);

            return Recepist;
        }

        public async Task<IEnumerable<Appointment>?> GetAppointmentsForReceptionist(int receptionistId)
        {
            var receptionistExist = await receptionistRepo.IsExist(receptionistId);

            if(!receptionistExist) 
                return null;



            var appointments = await receptionistRepo.GetAppointmentsForReceptionist(receptionistId);

            return appointments;
        }
    }
}
