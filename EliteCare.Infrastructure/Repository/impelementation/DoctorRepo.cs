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


        public async Task<IEnumerable<Appointment>> GetAppointments(int DoctorId)
        {
            var appointments = await _context.Appointments.Where(x => x.DoctorID == DoctorId).Include(x => x.Doctor).Include(x => x.Bill)
                                                          .ToListAsync();


            //var appointmentstoo = await _context.Receptionists.Where(x => x.ID == receptionistId)
            //                                                   .SelectMany(x => x.Appointments)
            //                                                   .ToListAsync();

            //var appointmentstoothree = await (from a in _context.Appointments
            //                                  join r in _context.Receptionists on a.ReceptionistID equals r.ID
            //                                  where r.ID == receptionistId
            //                                  select a).ToListAsync();



            return appointments;
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

