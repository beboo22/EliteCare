using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface INurseService
    {


        Task<ApiResponse> DeleteNurseAsync(int id);
        Task<ApiResponse> UpdateNurseAsync(Nurse nurse, Address address);
        Task<ApiResponse> AddNurseAsync(Nurse nurse, Address address);


        Task<IEnumerable<Nurse>> GetAllNurse();
        Task<Nurse> GetNurseByIdSpec(int id);


        Task<Nurse> GetNurseByEmailSpec(string email);
        Task<IEnumerable<Nurse>> GetNursesGovernRoom(int RoomId);



    }
}
