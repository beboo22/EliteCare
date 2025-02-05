using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public DeleteDoctorCommand(int id)
        {
            Id = id;
        }
    }
}
