using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class FeedBack:BaseEntity
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string Note { get; set; }
    }
}
