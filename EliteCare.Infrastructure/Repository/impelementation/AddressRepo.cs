using EliteCare.Data.Entities;
using EliteCare.Infrastructure.Data;
using EliteCare.Infrastructure.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Infrastructure.Repository.impelementation
{
    public class AddressRepo : IAddressRepo
    {
        public AddressRepo(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public ApplicationDbContext _db { get; }

        public async Task<bool> AddAddressAsync(Address address)
        {
            try
            {
                await _db.Set<Address>().AddAsync(address);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool DeleteAddress(Address address)
        {
            try
            {
                _db.Set<Address>().Remove(address);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<Address> GetAddress(int id)
        {
           return await _db.Set<Address>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public bool UpdateAddress(Address address)
        {
            try
            {
                _db.Set<Address>().Update(address);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
