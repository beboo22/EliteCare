using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Commands.Models
{
    public class DeleteAppointmentCommand : IRequest<ApiResponse>
    {
        public int ID { get; set; }

        public DeleteAppointmentCommand(int iD)
        {
            ID = iD;
        }
    }
}
