using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class SpecialistDoctorInDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
