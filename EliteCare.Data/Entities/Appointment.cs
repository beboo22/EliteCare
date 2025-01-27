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
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int ReceptionistID { get; set; }
        public int RoomID { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Receptionist Receptionist { get; set; }
        public Room Room { get; set; }


        public Status Status { get; set; }
    }
}
