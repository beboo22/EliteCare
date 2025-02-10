using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                await _context.Set<T>().AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Detached;
                entity.UpdatedAt = DateTime.Now;
                _context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public IQueryable<T> GetAllAsync()
        {
            var query = _context.Set<T>().AsQueryable();
            return query;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x=>x.ID == id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetBySpecification(ISpecification<T> specification)
        {
            var query = SpecificationEvaluation<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
            try
            {

                var data = await query.AsNoTracking().ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }
        public async Task<T?> GetByIDSpecification(ISpecification<T> specification)
        {
            var query = await SpecificationEvaluation<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).FirstOrDefaultAsync();
            return query ?? null;
        }
        public async Task<bool> IsExist(int Id)
        {
            try
            {
                return await _context.Set<T>().AnyAsync(x => x.ID == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
