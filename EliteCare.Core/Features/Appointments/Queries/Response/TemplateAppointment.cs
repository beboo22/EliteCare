using EliteCare.Core.Dtos;
using EliteCare.Data.Entities;
using EliteCare.Data.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Queries.Response
{
    internal class TemplateAppointment
    {
        public int AppointmentID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int? ReceptionistID { get; set; }
        public int? RoomID { get; set; }
        public int? PrescriptionID { get; set; }
        public int? BillID { get; set; }

        public DoctorReturnToAppointmentDtos Doctor { get; set; }

        public PatientReturnToAppointmentDtos Patient { get; set; }

        public ReceptionistReturnToAppointmentDtos Receptionist { get; set; }

        public RoomReturnToAppointmentDtos Room { get; set; }
        [ForeignKey(nameof(PrescriptionID))]
        public PrescriptionReturnToAppointmentDto prescription { get; set; }

        public BillReturnDto? Bill { get; set; }
        public string Status { get; set; }
    }
}
