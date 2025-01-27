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
        public NurseSpecification(string Email):base(n=>(string.IsNullOrEmpty(Email) || n.Email.ToLower() == Email.ToLower()))
        {
         AddInclude(n => n.Address);
        }
    }
}
