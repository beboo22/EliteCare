using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IReceptionistService
    {
        Task<ApiResponse> DeleteReceptionistAsync(int id);
        Task<ApiResponse> UpdateReceptionistAsync(Receptionist Receptionist, Address address);
        Task<ApiResponse> AddReceptionistAsync(Receptionist Receptionist, Address address);



        Task<IEnumerable<Receptionist>> GetAllReceptionist();
        Task<Receptionist> GetReceptionistByIdSpec(int id);
        Task<Receptionist> GetReceptionistByEmail(string email);

        Task<IEnumerable<Appointment>?> GetAppointmentsForReceptionist(int receptionistId);

    }
}
