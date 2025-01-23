using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Data.Entities
{
    public class Appointment :BaseEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public Status Status { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
