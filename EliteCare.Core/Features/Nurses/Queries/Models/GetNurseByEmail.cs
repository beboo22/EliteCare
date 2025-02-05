using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Models
{
    public class GetNurseByEmail:IRequest<ApiResultResponse<TemplateNurse>>
    {
        public GetNurseByEmail(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
