using EliteCare.Core.BaseResponse;
using EliteCare.Core.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class UpdateDoctorCommand: IRequest<ApiResultResponse<String>>
    {
        public DoctorDtos doctorDtos { get; set; }
        public UpdateDoctorCommand(DoctorDtos _doctorDtos)
        {
            doctorDtos = _doctorDtos;
        }
    }
}
