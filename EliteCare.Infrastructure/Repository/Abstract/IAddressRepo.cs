using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteCare.Data.Entities;

namespace EliteCare.Infrastructure.Repository.Abstract
{
    public interface IAddressRepo
    {
        Task<bool> AddAddressAsync(Address address);
        bool DeleteAddress(Address id);
        bool UpdateAddress(Address address);
        Task<Address> GetAddress(int id);
    }
}
