using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.impelementation
{
    public class BillRepo : IBillRepo
    {
        ApplicationDbContext _context;

        public BillRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Bill GetByOrderddId(int oderdId)
        {
            var exist = _context.Set<Bill>().Where(x=>x.OdrederID == oderdId).FirstOrDefault();
            return exist;
        }
    }
}
