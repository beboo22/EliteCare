using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.specificationCriteria
{
    public class AppointmentSpecification : Specification<Appointment>
    {
        public AppointmentSpecification(int? id) : base(x => (!id.HasValue || x.ID == id.Value))
        {
            AddInclude(x => x.Patient);
            AddInclude(x => x.Doctor);
            AddInclude(x => x.Receptionist);
            AddInclude(x => x.Room);
            AddInclude(x => x.prescription);
            AddInclude(x => x.Bill);
        }
    }
}
