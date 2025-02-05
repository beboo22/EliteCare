using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorById : IRequest<ApiResultResponse<TemplateDoctor>>
    {
        public GetDoctorById(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
