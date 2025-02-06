using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IDepartmentService
    {
        Task<ApiResponse> DeleteDepartmentAsync(int id);
        ApiResponse UpdateDepartmentAsync(Department Department);
        Task<ApiResponse> AddDepartmentAsync(Department Department);



        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartmentByIdSpec(int id);
    }
}
