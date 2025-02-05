using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorsForDept : IRequest<ApiResultResponse<List<TemplateDoctor>>>
    {
        public int DepartmentId { get; set; }

        public GetDoctorsForDept(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
