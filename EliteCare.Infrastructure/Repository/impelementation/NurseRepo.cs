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
    public class NurseRepo : GenericRepository<Nurse>, INurseRepo
    {
        public NurseRepo(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Nurse?> GetNurseByEmail(string email)
        {
            var nurse = await _context.Nurses.FirstOrDefaultAsync(x => x.Email == email);
            return nurse ?? null;
        }
    }
}

