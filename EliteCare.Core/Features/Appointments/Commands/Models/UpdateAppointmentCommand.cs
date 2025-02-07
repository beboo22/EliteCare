using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Commands.Models
{
    public class UpdateAppointmentCommand : IRequest<ApiResponse>
    {
        public UpdateAppointmentDtos appointmentDtos { get; set; }

        public UpdateAppointmentCommand(UpdateAppointmentDtos appointmentDtos)
        {
            this.appointmentDtos = appointmentDtos;
        }
    }
}
