using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.specificationCriteria
{
    internal class NurseSpecification: Specification<Nurse>
    {
        public NurseSpecification(string? Email, int? id) :base(n=>(string.IsNullOrEmpty(Email) || n.Email.ToLower() == Email.ToLower()&&(n.ID == id)))
        {
         AddInclude(n => n.Address);
            AddInclude(n=>n.GovernRoom);
        }
    }
}
