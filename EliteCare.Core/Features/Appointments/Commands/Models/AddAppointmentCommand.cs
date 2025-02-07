using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Appointments.Commands.Handlers;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Commands.Models
{
    public class AddAppointmentCommand : IRequest<ApiResponse>
    {
        public AddAppointmentDtos appointmentDtos { get; set; }

        public AddAppointmentCommand(AddAppointmentDtos appointmentDtos)
        {
            this.appointmentDtos = appointmentDtos;
        }
    }
}
