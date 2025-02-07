using EliteCare.Core.Dtos;
using EliteCare.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Response
{
    public class TemplateForAppointment_Receptionist
    {
        public int ReceptionistId { get; set; }
        public ICollection<AppointmentReturnDto> Appointment { get; set; }
    }
}
