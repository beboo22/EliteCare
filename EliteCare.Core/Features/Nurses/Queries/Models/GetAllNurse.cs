using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Models
{
    public class GetAllNurse:IRequest<ApiResultResponse<List<TemplateNurse>>>
    {
    }
}
