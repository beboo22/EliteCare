using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IPatientService
    {

        Task<ApiResponse> DeletePatientAsync(int id);
        Task<ApiResponse> UpdatePatientAsync(Patient Patient, Address address);
        Task<ApiResponse> AddPatientAsync(Patient Patient, Address address);



        Task<IEnumerable<Patient>> GetAllPatient();
        Task<Patient> GetPatientByIdSpec(int id);
        Task<Patient> GetPatientByEmail(string email);

        Task<IEnumerable<Appointment>?> GetAppointmentsForPatient(int PatientId);





    }
}
