using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Validations
{
    public class TemplateSpecialist
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
