using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Appointments.Queries.Models
{
    public class GetByIdAppointmentQuery :IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public GetByIdAppointmentQuery(int id)
        {
            Id = id;
        }
    }
}
