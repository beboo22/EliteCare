using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface ICachedService <T> where T : BaseEntity
    {
        Task AddCachedData(string key, T Requestdata);
        Task RemoveCachedData(string key);
    }
}
