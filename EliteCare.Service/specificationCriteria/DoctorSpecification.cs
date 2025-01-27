using EliteCare.Data.Entities;
using EliteCare.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.specificationCriteria
{
    internal class DoctorSpecification:Specification<Doctor>
    {

        public DoctorSpecification(string? Email,int? id, int? departmentid)
            : base(d => (string.IsNullOrEmpty(Email) || d.Email.ToLower() == Email.ToLower())
                  && (!id.HasValue|| d.ID == id.Value)
                  && (!departmentid.HasValue || d.DepartmentId == departmentid.Value))
        {
            AddInclude(d => d.Department);
            AddInclude(d => d.SpecialistDoctorInDepartment);
            AddInclude(d=>d.Address);
        }





    }
}
