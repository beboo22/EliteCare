using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IDoctorService
    {
        Task<ApiResponse> DeleteDoctorAsync(int id);
        Task<ApiResponse> UpdateDoctorAsync(Doctor doctor, Address address);
        Task<ApiResponse> AddDoctorAsync(Doctor doctor, Address address);

        

        Task<IEnumerable<Doctor>> GetAllDoctor();
        Task<Doctor> GetDoctorByIdSpec(int id);
        Task<Doctor> GetDoctorByEmail(string email);


        Task<IEnumerable<Doctor>> GetDoctorForDeptSpec(int num);
        Task<Doctor> GetDoctorByEmailSpec(string email);


        Task<IEnumerable<Doctor>> SpecialistDoctorInDepartment(int departmentId);
        Task<IEnumerable<Doctor>> GetDoctorForDept(int departmentId);
    }
}
