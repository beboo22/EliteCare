using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    internal interface ISpecialistDoctorInDepartmentService
    {
        Task<bool> AddSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist);

        Task<IEnumerable<SpecialistDoctorInDepartment>> GetSpecialistDoctorInDepartment(int departmentId);
        Task<bool> DeleteSpecialistDoctorInDepartment(int doctorId);
        Task<bool> UpdateSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist);

        Task<IEnumerable<SpecialistDoctorInDepartment>> GetAllSpecialistDoctorInDepartment();

    }
}
