using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByEmail : IRequest<ApiResultResponse<TemplateDoctor>>
    {
        public GetDoctorByEmail(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
