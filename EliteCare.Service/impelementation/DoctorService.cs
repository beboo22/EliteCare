using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using EliteCare.Service.specificationCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class DoctorService : IDoctorService
    {

        public IUnitOfWork _unitOfWork;
        public IDoctorRepo DoctorRepo { get; set; }
        ApplicationDbContext _context;
        IAddressRepo _addressRepo { get; set; }

        public DoctorService(IDoctorRepo doctorRepo, IUnitOfWork unitOfWork, ApplicationDbContext context, IAddressRepo addressRepo)
        {
            DoctorRepo = doctorRepo;
            _unitOfWork = unitOfWork;
            _context = context;
            _addressRepo = addressRepo;
        }

        public async Task<Doctor> GetDoctorByEmail(string email)
        {
            return await DoctorRepo.GetDoctorByEmail(email);
        }
        public async Task<IEnumerable<Doctor>> GetDoctorForDept(int departmentId)
        {
            return await DoctorRepo.GetDoctorForDept(departmentId);
        }
        public async Task<IEnumerable<Doctor>> SpecialistDoctorInDepartment(int departmentId)
        {
            return await DoctorRepo.SpecialistDoctorInDepartment(departmentId);
        }


        // using Specification pattern

        public async Task<Doctor> GetDoctorByEmailSpec(string email)
        {
            string Email = email;
            var spec = new DoctorSpecification(Email, null, null);
            var doctor = (await DoctorRepo.GetBySpecification(spec)).FirstOrDefault();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorForDeptSpec(int num)
        {
            int depatmentId = num;
            var spec = new DoctorSpecification(null, null, depatmentId);
            var doctor = await DoctorRepo.GetBySpecification(spec);
            return doctor;
        }


        // crud operations
        public async Task<ApiResponse> AddDoctorAsync(Doctor doctor, Address address)
        {
            if (doctor.DepartmentId.HasValue)
            {
                var depart = _unitOfWork.Repo<Department>();

                var IsExist = await depart.IsExist(doctor.DepartmentId.Value);
                if (!IsExist)
                {
                    new ApiResponse(404, "Department NotFound");

                }
            }


            var flag = await _addressRepo.AddAddressAsync(address);

            if (!flag) return new ApiResponse(500, "Error while Adding, Can't Add Address");
            int check = await _unitOfWork.Commit();
            if (check < 0) return new ApiResponse(500, $"Error While Saving Changing AddessID{address.Id}");


            doctor.AddressId = address.Id;

            flag = await DoctorRepo.AddAsync(doctor);
            if (flag)
            {
                check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Adding");
        }

        public async Task<ApiResponse> UpdateDoctorAsync(Doctor doctor, Address address)
        {
            var doc = await DoctorRepo.GetByIdAsync(doctor.ID);
            if (doc is null)
            {
                return new ApiResponse(404, "Doctor Don't Existing");
            }
            if (address is not null)
            {
                address.Id = doc.AddressId;
                var  check = _addressRepo.UpdateAddress(address);
                if (!check) return new ApiResponse(500, "Error While Updating and The Reason is Address");

                doctor.Address = address;
                doctor.AddressId = address.Id;
            }

            bool flag = DoctorRepo.Update(doctor);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Update Doctor");
        }

        public async Task<ApiResponse> DeleteDoctorAsync(int id)
        {
            var doc = await DoctorRepo.GetByIdAsync(id);
            if (doc is null)
            {
                return new ApiResponse(404, "Doctor Don't Existing");
            }

            if (doc.AddressId != 0)
            {
                var add = await _addressRepo.GetAddress(doc.AddressId);
                if (add is not null)
                {
                    var  check = _addressRepo.DeleteAddress(add);
                    if (!check) return new ApiResponse(500, "Error While delating and Can't Delete Address");
                }
                return new ApiResponse(404, "Address Not Found");
            }
            var flag = DoctorRepo.Delete(doc);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Deleting Doctor");
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var DoctorSpec = new DoctorSpecification(null, null, null);
            var AllDoctor = await DoctorRepo.GetBySpecification(DoctorSpec);

            return AllDoctor;


        }

        public async Task<Doctor?> GetDoctorByIdSpec(int id)
        {
            var DoctorSpec = new DoctorSpecification(null, id, null);
            var doctor = await DoctorRepo.GetByIDSpecification(DoctorSpec);

            return doctor;
        }

        
    }
}
