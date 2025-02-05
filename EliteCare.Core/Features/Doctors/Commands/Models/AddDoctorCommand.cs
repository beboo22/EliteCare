using EliteCare.Core.Mapping;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class AddDoctorCommand : IRequest<ApiResponse>
    {
        public AddDoctorDtos doctorDtos { get; set; }
        public AddDoctorCommand(AddDoctorDtos _doctorDtos)
        {
            doctorDtos = _doctorDtos;
        }
    }
}
