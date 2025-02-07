using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Queries.Models
{
    public class GetAllPatientForReceptionist : IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public GetAllPatientForReceptionist(int id)
        {
            Id = id;
        }
    }
}
