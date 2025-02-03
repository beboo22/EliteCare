using EliteCare.Core.BaseResponse;
using EliteCare.Core.Dtos;
using EliteCare.Core.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class AddDoctorCommand : IRequest<ApiResultResponse<String>>
    {
        public AddDoctorDtos doctorDtos { get; set; }
        public AddDoctorCommand(AddDoctorDtos _doctorDtos)
        {
            doctorDtos = _doctorDtos;
        }
    }
}
