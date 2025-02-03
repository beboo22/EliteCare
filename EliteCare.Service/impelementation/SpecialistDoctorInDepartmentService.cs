using EliteCare.Data.Entities;
using EliteCare.Infrastructure;
using EliteCare.Infrastructure.Data;
using EliteCare.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    internal class SpecialistDoctorInDepartmentService : ISpecialistDoctorInDepartmentService
    {
        public ApplicationDbContext _context { get; set; }
        public IUnitOfWork _unitOfWork { get; }

        public SpecialistDoctorInDepartmentService(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist)
        {
            try
            {
                await _context.Set<SpecialistDoctorInDepartment>().AddAsync(specialist);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> GetSpecialistDoctorInDepartment(int departmentId)
        {
            var items = await _context.Set<SpecialistDoctorInDepartment>().Where(x => x.DepartmentId == departmentId).ToListAsync();
            return items;
        }

        public async Task<bool> DeleteSpecialistDoctorInDepartment(int doctorId)
        {
            try
            {
                var item = await _context.Set<SpecialistDoctorInDepartment>().AsNoTracking().FirstOrDefaultAsync(x => x.DoctorId == doctorId);
                if (item is not null)
                {
                    _context.Set<SpecialistDoctorInDepartment>().Remove(item);
                    if (await _unitOfWork.Commit() > 0)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSpecialistDoctorInDepartment(SpecialistDoctorInDepartment specialist)
        {
            _context.Set<SpecialistDoctorInDepartment>().Update(specialist);

            if (await _unitOfWork.Commit() > 0)
                return true;
            return false;
        }

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> GetAllSpecialistDoctorInDepartment()
        {
            var items = await _context.Set<SpecialistDoctorInDepartment>().AsNoTracking().ToListAsync();
            return items ?? new List<SpecialistDoctorInDepartment>();
        }
    }
}
