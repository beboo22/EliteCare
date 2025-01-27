using EliteCare.Core.BaseResponse;
using EliteCare.Core.Features.Doctors.Queries.Response;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetAllDoctor : IRequest<ApiResultResponse<List<TemplateDoctor>>>
    {
    }
}
