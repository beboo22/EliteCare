using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartment.Commands.Models
{
    public class AddSpecialistDoctorCommand : IRequest<ApiResponse>
    {
        public AddSpecialistDoctorCommand(AddSpecialistDoctorDtos doctorDtos)
        {
            SpecialistDoctorDtos = doctorDtos;
        }

        public AddSpecialistDoctorDtos SpecialistDoctorDtos { get; }
    }
}
