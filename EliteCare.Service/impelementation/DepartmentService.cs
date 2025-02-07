using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Repository.Abstract;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class DepartmentService : IDepartmentService
    {
        IUnitOfWork unitOfWork;
        IGenericRepository<Department> repo {  get; set; }
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = unitOfWork.Repo<Department>();
        }

        public async Task<ApiResponse> DeleteDepartmentAsync(int id)
        {
            var dep =await repo.GetByIdAsync(id);
            var check = repo.Delete(dep);
            return check is true ? new ApiResponse(200) : new ApiResponse(500, "Can't Delete Department");

        }

        public ApiResponse UpdateDepartmentAsync(Department Department)
        {
            Department.UpdatedAt = DateTime.Now;
            var check = repo.Update(Department);
            return check is true?new ApiResponse(200): new ApiResponse(500,"Can't Update Department");
        }

        public async Task<ApiResponse> AddDepartmentAsync(Department Department)
        {
            var check = await repo.AddAsync(Department);
            return check is true ? new ApiResponse(200) : new ApiResponse(500, "Can't Add Department");
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            var items = await repo.GetAllAsync().ToListAsync();
            return items;
        }

        public async Task<Department> GetDepartmentByIdSpec(int id)
        {
            var items = await repo.GetByIdAsync(id);
            return items;
        }
    }
}
