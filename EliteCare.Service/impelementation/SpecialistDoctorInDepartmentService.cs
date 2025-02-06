using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class SpecialistDoctorInDepartmentService : ISpecialistDoctorInDepartmentService
    {
        public ISpecialistDoctorInDepartmentRepo specialistRepo { get; set; }
        public IDoctorRepo doctorRepo { get; set; }
        IUnitOfWork unitOfWork { get; set; }
        public SpecialistDoctorInDepartmentService(ISpecialistDoctorInDepartmentRepo specialist, IDoctorRepo doctorRepo, IUnitOfWork unitOfWork)
        {
            this.specialistRepo = specialist;
            this.doctorRepo = doctorRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse> AddSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist)
        {
            var Checkdoc = await doctorRepo.IsExist(specialist.DoctorId);
            if (!Checkdoc) return new ApiResponse(404, "Doctor Don't Existing");
            

            var deptRepo = unitOfWork.Repo<Department>();
            var checkDep = await deptRepo.IsExist(specialist.DepartmentId);
            if (!checkDep) return new ApiResponse(404, "Department Don't Existing");


            var checkSpecialist = await specialistRepo.AddspecialistAsync(specialist);
            if (checkSpecialist)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Adding");
        }       
        

        public async Task<ApiResponse> DeleteSpecialistDoctorInDepartment(int doctorId)
        {
            var Checkdoc = await doctorRepo.IsExist(doctorId);
            if (!Checkdoc) return new ApiResponse(404, "Doctor Don't Existing");
            
            var item = await specialistRepo.GetDoctorItem(doctorId);

            var checkSpecialist =  specialistRepo.Deletespecialist(item);
            if (checkSpecialist)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Deleting");
        }

        public async Task<ApiResponse> UpdateSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist)
        {
            var checkDocExists = specialistRepo.GetDoctorItem(specialist.DoctorId);
            if (checkDocExists is null) return new ApiResponse(404, "There's not specialist Doctor by this ID");

            var DepRepo = unitOfWork.Repo<Department>();
            var checkDepExists = await DepRepo.IsExist(specialist.DepartmentId);
            if (!checkDepExists) return new ApiResponse(404, "There's not Department by this ID");

            var checkSpecialist = specialistRepo.Updatespecialist(specialist);
            if (checkSpecialist)
            {
                int check = await unitOfWork.Commit();
                if (check < 0) return new ApiResponse(500, "Error While Saving Changing");
                return new ApiResponse(200);
            }
            return new ApiResponse(500, "Error while Adding");
        }

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> GetAllSpecialistDoctorInDepartment(int Departmentid)
        => await specialistRepo.GetSpecialistDoctorInDepartment(Departmentid);

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> GetAll()
        => await specialistRepo.Getall();
    }
}
