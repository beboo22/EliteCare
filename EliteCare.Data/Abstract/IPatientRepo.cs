using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Abstract
{
    public interface IPatientRepo : IGenericRepository<Patient>
    {
        Task<Patient> GetPatientByEmail(string email);
        Task<IEnumerable<Appointment>> GetAppointmentsForPatient(int patientId);
    }
}
