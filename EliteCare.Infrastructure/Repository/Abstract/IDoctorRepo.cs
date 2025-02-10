using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.Abstract
{
    public interface IDoctorRepo : IGenericRepository<Doctor>
    {
        Task<Doctor> GetDoctorByEmail(string email);
        Task<IEnumerable<Doctor>> GetDoctorForDept(int departmentId);
        Task<IEnumerable<Doctor>> SpecialistDoctorInDepartment(int departmentId);
        Task<IEnumerable<Appointment>> GetAppointments(int DoctorId);
    }
}
