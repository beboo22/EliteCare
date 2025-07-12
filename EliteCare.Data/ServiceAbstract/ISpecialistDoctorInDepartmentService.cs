using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.ServiceAbstract
{
    public interface ISpecialistDoctorInDepartmentService
    {
        Task<ApiResponse> AddSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist);
        Task<ApiResponse> UpdateSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist);
        Task<ApiResponse> DeleteSpecialistDoctorInDepartment(int doctorId);
        Task<IEnumerable<SpecialistDoctorInDepartment>> GetAllSpecialistDoctorInDepartment(int Departmentid);
        Task<IEnumerable<SpecialistDoctorInDepartment>> GetAll();
    }
}
