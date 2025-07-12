using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Delete(T entity);


        Task<bool> IsExist(int Id);

        Task<IEnumerable<T>> GetBySpecification(ISpecification<T> specification);

        Task<T?> GetByIDSpecification(ISpecification<T> specification);

    }
}
