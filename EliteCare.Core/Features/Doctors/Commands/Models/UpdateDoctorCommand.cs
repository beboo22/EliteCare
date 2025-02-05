using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class UpdateDoctorCommand: IRequest<ApiResponse>
    {
        public UpdateDoctorDtos doctorDtos { get; set; }
        public UpdateDoctorCommand(UpdateDoctorDtos _doctorDtos)
        {
            doctorDtos = _doctorDtos;
        }
    }
}
