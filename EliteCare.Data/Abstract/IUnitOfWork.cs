using EliteCare.Data.Abstract;
using EliteCare.Data.Entities;

namespace EliteCare.Data
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repo<T>() where T : BaseEntity, new();
        Task<int> Commit();
        void Dispose();
    }
}
