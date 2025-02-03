using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Service.Abstract;
using EliteCare.Service.specificationCriteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class DoctorService : IDoctorService
    {

        public IUnitOfWork _unitOfWork;
        public IDoctorRepo DoctorRepo { get; set; }
        ApplicationDbContext _context;

        public DoctorService(IDoctorRepo doctorRepo, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            DoctorRepo = doctorRepo;
            _unitOfWork = unitOfWork;
            _context = context;
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
        public async Task<bool> AddDoctorAsync(Doctor doctor, Address address)
        {
            if (doctor.DepartmentId.HasValue)
            {
                var depart = _unitOfWork.Repo<Department>();

                var IsExist = await depart.IsExist(doctor.DepartmentId.Value);
                if (!IsExist)
                {
                    doctor.DepartmentId = null;
                }
            }
            _context.Set<Address>().Add(address);
            await _unitOfWork.Commit();
            doctor.AddressId = address.Id;

            bool flag = await DoctorRepo.AddAsync(doctor);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                flag = check > 0;
            }
            return flag;
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor, Address address)
        {
            var doc = await DoctorRepo.GetByIdAsync(doctor.ID);
            if (doc is null)
            {
                return false;
            }
            if (address is not null)
            {
                address.Id = doc.AddressId;
                try
                {
                    _context.Set<Address>().Update(address);

                }
                catch (Exception ex)
                {
                    throw;
                }
                doctor.Address = address;
                doctor.AddressId = address.Id;
            }

            bool flag = DoctorRepo.Update(doctor);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                flag = check > 0;
            }
            return flag;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await DoctorRepo.GetByIdAsync(id);

            if (doctor is null)
            {
                return false;
            }
            if (doctor.AddressId != 0)
            {
                var add = await _context.Set<Address>().FindAsync(doctor.AddressId);
                if (add is not null)
                {
                    try
                    {
                        _context.Set<Address>().Remove(add);

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            var flag = DoctorRepo.Delete(doctor);
            if (flag)
            {
                int check = await _unitOfWork.Commit();
                flag = check > 0;
            }
            return flag;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var DoctorSpec = new DoctorSpecification(null, null, null);
            var AllDoctor = await DoctorRepo.GetBySpecification(DoctorSpec);

            return AllDoctor;


        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            var DoctorSpec = new DoctorSpecification(null, id, null);
            var doctor = await DoctorRepo.GetByIDSpecification(DoctorSpec);

            return doctor;
        }

        
    }
}
