using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Infrastructure.Repository.impelementation;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using EliteCare.Service.specificationCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class NurseService : INurseService
    {
        public NurseService(IUnitOfWork unitOfWork, IAddressRepo addressRepo, INurseRepo nurseRepo)
        {
            _unitOfWork = unitOfWork;
            _addressRepo = addressRepo;
            _nurseRepo = nurseRepo;
        }

        public IUnitOfWork _unitOfWork { get; }
        public INurseRepo _nurseRepo { get; set; }
        public IAddressRepo _addressRepo { get; set; }


        public async Task<ApiResponse> AddNurseAsync(Nurse nurse, Address address)
        {
            if (nurse.RoomID.HasValue)
            {
                var roomExist = await _unitOfWork.Repo<Room>().IsExist(nurse.RoomID.Value);
                if (!roomExist)
                    return new ApiResponse(404,"Room NotFound");
            }

            var flag = await _addressRepo.AddAddressAsync(address);
            if (!flag)
            {
                return new ApiResponse(500, "Error While Adding and The Reason is Address");
            }

            flag = await _nurseRepo.AddAsync(nurse);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error While Adding Nurse");


        }

        public async Task<ApiResponse> UpdateNurseAsync(Nurse nurse, Address address)
        {
            var nursecheck = await _nurseRepo.GetByIdAsync(nurse.ID);
            if (nursecheck is null)
            {
                return new ApiResponse(404, "Nurse Don't Existing");
            }
            address.Id = nursecheck.AddressId;
            var flag = _addressRepo.UpdateAddress(address);
            if (!flag) return new ApiResponse(500, "Error While Updating and The Reason is Address");

            nurse.Address = address;
            nurse.UpdatedAt = DateTime.Now;
            flag = _nurseRepo.Update(nurse);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error While updating Nurse");

        }
        public async Task<ApiResponse> DeleteNurseAsync(int id)
        {
            var nures = await _nurseRepo.GetByIdAsync(id);

            if(nures is null) return new ApiResponse(404, "Nurse NotFound");


            var address = await _addressRepo.GetAddress(nures.AddressId);


            var flag = _addressRepo.DeleteAddress(address);
            if (!flag) return new ApiResponse(500, "Error While delating and Can't Delete Address");




            flag = _nurseRepo.Delete(nures);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error While delating Nurse");
        }

        public async Task<IEnumerable<Nurse>> GetAllNurse()
        {

            var nuresSpec = new NurseSpecification(null, null, null);
            if (nuresSpec is not null)
            {
                var nurses = await _nurseRepo.GetBySpecification(nuresSpec);

                return nurses;
            }
            return new List<Nurse>();
        }

        public async Task<Nurse> GetNurseByEmailSpec(string email)
        {
            var nuresSpec = new NurseSpecification(email, null, null);

            var nurses = (await _nurseRepo.GetBySpecification(nuresSpec)).FirstOrDefault();

            return nurses;
        }

        public async Task<Nurse?> GetNurseByIdSpec(int id)
        {
            var nuresSpec = new NurseSpecification(null, id, null);

            var nurses = (await _nurseRepo.GetByIDSpecification(nuresSpec));

            return nurses ?? null;
        }

        public async Task<IEnumerable<Nurse>> GetNursesGovernRoom(int RoomId)
        {
            var nuresSpec = new NurseSpecification(null, null, RoomId);
            var nurse = await _nurseRepo.GetBySpecification(nuresSpec);
            return nurse;
        }

    }
}
