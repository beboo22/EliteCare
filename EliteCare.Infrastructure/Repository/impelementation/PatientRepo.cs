using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.impelementation
{
    public class PatientRepo : GenericRepository<Patient>, IPatientRepo
    {
        public PatientRepo(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatient(int patientId)
        {
            var appointments = await _context.Appointments.Where(x => x.PatientID == patientId)
                                                          //.Include(x=>x.Doctor)
                                                          //.Include(x=>x.prescription)
                                                          .ToListAsync();

            var appointmentstoo = await _context.Patients.Where(x => x.ID == patientId)
                                                         .SelectMany(x => x.Appointments)
                                                         .ToListAsync();

            var appointmentsthree = await (from a in _context.Appointments
                                              join r in _context.Patients on a.PatientID equals patientId
                                              //where r.ID == patientId
                                           select a).ToListAsync();

            return appointmentstoo;
        }

        public async Task<Patient?> GetPatientByEmail(string email)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Email == email);
            return patient ?? null;
        }
    }
}
