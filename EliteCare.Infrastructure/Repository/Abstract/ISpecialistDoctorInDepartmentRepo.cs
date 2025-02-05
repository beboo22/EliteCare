using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.Abstract
{
    public interface ISpecialistDoctorInDepartmentRepo
    {
        Task<bool> AddspecialistAsync(SpecialistDoctorInDepartment specialist);
        bool Deletespecialist(SpecialistDoctorInDepartment id);
        bool Updatespecialist(SpecialistDoctorInDepartment address);
        Task<IEnumerable<SpecialistDoctorInDepartment>> GetSpecialistDoctorInDepartment(int id);
        Task<IEnumerable<SpecialistDoctorInDepartment>> Getall();
        Task<SpecialistDoctorInDepartment> GetDoctorItem(int id);
    }
}
