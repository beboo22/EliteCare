using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Repository.Abstract;

namespace EliteCare.Infrastructure
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repo<T>() where T : BaseEntity, new();
        Task<int> Commit();
        void Dispose();
    }
}
