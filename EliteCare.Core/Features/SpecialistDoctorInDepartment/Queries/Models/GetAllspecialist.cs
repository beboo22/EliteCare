using EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Validations;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Models
{
    public class GetAllspecialist : IRequest<ApiResultResponse<List<TemplateSpecialist>>>
    {
    }
}
