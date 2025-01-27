using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.impelementation
{
    public class DoctorRepo : GenericRepository<Doctor>, IDoctorRepo
    {
        public DoctorRepo(ApplicationDbContext context) : base(context)
        {
        }


        public Task<IEnumerable<Appointment>> GetAppointments(int AppointmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Doctor?> GetDoctorByEmail(string email)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Email == email);
            return doctor ?? null;
        }
        public async Task<IEnumerable<Doctor>?> GetDoctorForDept(int departmentId)
        {
            var doctors = await _context.Doctors.Where(x => x.DepartmentId == departmentId).ToListAsync();
            return doctors.Count() > 0 ? doctors : null;
        }
        public async Task<IEnumerable<Doctor>?> SpecialistDoctorInDepartment(int departmentId)
        {
            var doctors = await _context.Doctors.Where(x => x.SpecialistDoctorInDepartment.DepartmentId == departmentId).ToListAsync();

            return doctors.Count() > 0 ? doctors : null;

        }
    }

}

