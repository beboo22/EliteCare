using EliteCare.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Queries.Response
{
    public class TemplateForAppointment_Patient
    {
        public int PatientID { get; set; }
        public ICollection<AppointmentReturnDto> Appointment { get; set; }
    }
}
