using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Models
{
    public class UpdateSpecialistDoctorCommand : IRequest<ApiResponse>
    {
        public UpdateSpecialistDoctorCommand(AddSpecialistDoctorDtos doctorDtos)
        {
            SpecialistDoctorDtos = doctorDtos;
        }

        public AddSpecialistDoctorDtos SpecialistDoctorDtos { get; }
    }
}
