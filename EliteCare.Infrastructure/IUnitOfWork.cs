using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure
{
    internal interface IUnitOfWork 
    {
         IGenericRepository<T> Repo<T>() where T : BaseEntity, new();

         Task<int> Commit();
         void Dispose();
    }
}
