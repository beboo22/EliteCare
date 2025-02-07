using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Dtos
{
    public class UpdateAppointmentDtos
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int? ReceptionistID { get; set; }
        public int? RoomID { get; set; }
        public int? PrescriptionID { get; set; }
        public int? BillID { get; set; }

        public int Status { get; set; }
    }
}
