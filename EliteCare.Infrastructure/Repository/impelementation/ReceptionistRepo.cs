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
    internal class ReceptionistRepo : GenericRepository<Receptionist>, IReceptionistRepo
    {
        public ReceptionistRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Receptionist?> GetReceptionistByEmail(string email)
        {
            var receptionist = await _context.Receptionists.FirstOrDefaultAsync(x => x.Email == email);
            return receptionist ?? null;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsForReceptionist(int receptionistId)
        {
            var appointments = await _context.Appointments.Where(x => x.ReceptionistID == receptionistId)
                                                          .ToListAsync();


            var appointmentstoo = await _context.Receptionists.Where(x => x.ID == receptionistId)
                                                               .SelectMany(x => x.Appointments)
                                                               .ToListAsync();

            var appointmentstoothree = await (from a in _context.Appointments
                                              join r in _context.Receptionists on a.ReceptionistID equals r.ID
                                              where r.ID == receptionistId
                                              select a).ToListAsync();



            return appointmentstoo;
        }
    }
}
