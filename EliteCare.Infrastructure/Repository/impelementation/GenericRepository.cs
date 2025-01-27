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

        public IQueryable<T> GetAll()
        {
            var query = _context.Set<T>().AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
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
                entity.UpdatedAt = DateTime.Now;
                _context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetBySpecification(ISpecification<T> specification)
        {
            var query = await SpecificationEvaluation<T>.GetQuery(_context.Set<T>().AsQueryable(), specification).ToListAsync();
            return query ?? new List<T>();
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
                var item = await _context.Set<T>().FindAsync(Id);

                return item is not null ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
