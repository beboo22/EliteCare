using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.Abstract
{
    internal interface IReceptionistRepo : IGenericRepository<Receptionist>
    {
        Task<Receptionist> GetReceptionistByEmail(string email);
        Task<IEnumerable<Appointment>> GetAppointmentsForReceptionist(int receptionistId);

    }
}
