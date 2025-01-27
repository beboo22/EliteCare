using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.Abstract
{
    internal interface INurseRepo : IGenericRepository<Nurse>
    {
        Task<Nurse> GetNurseByEmail(string email);
    }
}
