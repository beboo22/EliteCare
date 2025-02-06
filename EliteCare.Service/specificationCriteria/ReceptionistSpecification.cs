using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.specificationCriteria
{
    internal class ReceptionistSpecification : Specification<Receptionist>
    {
        public ReceptionistSpecification(string? Email, int? id)
            : base(d => (string.IsNullOrEmpty(Email) || d.Email.ToLower() == Email.ToLower())
                  && (!id.HasValue || d.ID == id.Value))
        {
            AddInclude(d => d.Appointments);
            AddInclude(d => d.Address);
        }
    }
}
