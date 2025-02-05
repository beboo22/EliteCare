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
    public class SpecialistDoctorInDepartmentRepo : ISpecialistDoctorInDepartmentRepo
    {
        public ApplicationDbContext _context { get; set; }

        public SpecialistDoctorInDepartmentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddspecialistAsync(SpecialistDoctorInDepartment specialist)
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

        public bool Deletespecialist(int id)
        {
            try
            {
                var item = _context.Set<SpecialistDoctorInDepartment>().AsNoTracking().FirstOrDefault(x => x.DoctorId == id);
                if (item != null)
                {
                    _context.Remove(item);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> Getall()
        {
            var items = await _context.Set<SpecialistDoctorInDepartment>().ToListAsync();
            return items;
        }

        public async Task<IEnumerable<SpecialistDoctorInDepartment>> GetSpecialistDoctorInDepartment(int id)
        {
            var items = await _context.Set<SpecialistDoctorInDepartment>().Where(x => x.DepartmentId == id).ToListAsync();
            return items;
        }

        public bool Updatespecialist(SpecialistDoctorInDepartment specialist)
        {
            try
            {
                _context.Set<SpecialistDoctorInDepartment>().Update(specialist);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Deletespecialist(SpecialistDoctorInDepartment id)
        {
            throw new NotImplementedException();
        }

        public async Task<SpecialistDoctorInDepartment?> GetDoctorItem(int id)
        {
            var item = await _context.Set<SpecialistDoctorInDepartment>().AsNoTracking().FirstOrDefaultAsync(x => x.DoctorId == id);
            return item is not null ? item : null;

        }
    }
}
