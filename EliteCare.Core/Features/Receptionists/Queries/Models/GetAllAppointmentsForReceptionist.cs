using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Models
{
    public class GetAllAppointmentsForReceptionist : IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public GetAllAppointmentsForReceptionist(int id)
        {
            Id = id;
        }
    }
}
