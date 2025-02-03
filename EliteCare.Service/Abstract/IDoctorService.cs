using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IDoctorService
    {
        Task<bool> DeleteDoctorAsync(int id);
        Task<bool> UpdateDoctorAsync(Doctor doctor, Address address);
        Task<bool> AddDoctorAsync(Doctor doctor, Address address);
        

        Task<IEnumerable<Doctor>> GetAllDoctor();
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctorForDeptSpec(int num);
        Task<Doctor> GetDoctorByEmailSpec(string email);
        Task<IEnumerable<Doctor>> SpecialistDoctorInDepartment(int departmentId);
        Task<IEnumerable<Doctor>> GetDoctorForDept(int departmentId);
        Task<Doctor> GetDoctorByEmail(string email);
    }
}
