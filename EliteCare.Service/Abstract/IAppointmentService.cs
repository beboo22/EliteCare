using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IAppointmentService
    {

        Task<ApiResponse> AddAppointment(Appointment appointment);
        Task<ApiResponse> UpdateAppointment(Appointment appointment);
        Task<ApiResponse> DeleteAppointment(int id);
        Task<IEnumerable<Appointment>> GetAppointment();
        Task<Appointment> GetAppointmentById(int id);
    }
}
