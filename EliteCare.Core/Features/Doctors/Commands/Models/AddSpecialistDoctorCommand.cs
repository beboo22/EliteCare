using EliteCare.Core.BaseResponse;
using EliteCare.Core.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class AddSpecialistDoctorCommand: IRequest<ApiResultResponse<String>>
    {
        public AddSpecialistDoctorCommand(AddSpecialistDoctorDtos doctorDtos)
        {
            DoctorDtos = doctorDtos;
        }

        public AddSpecialistDoctorDtos DoctorDtos { get; }
    }
}
