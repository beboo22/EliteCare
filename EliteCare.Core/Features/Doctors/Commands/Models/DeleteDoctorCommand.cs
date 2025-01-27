using EliteCare.Core.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommand : IRequest<ApiResultResponse<String>>
    {
        public int Id { get; set; }
        public DeleteDoctorCommand(int id)
        {
            Id = id;
        }
    }
}
