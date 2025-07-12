using EliteCare.Data.Entities;

namespace EliteCare.Data.ServiceAbstract
{
    public interface ICachedService <T> where T : BaseEntity
    {
        Task<bool> AddCachedData(string key, T Requestdata);
        Task RemoveCachedData(string key);
    }
}
