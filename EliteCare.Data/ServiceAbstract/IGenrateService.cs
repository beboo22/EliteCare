using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IGenrateService
    {
        Task<ISpecification<T>> GenerateService<T>(int id) where T : BaseEntity, new();
    }
}
