using EliteCare.Core.Features.Doctors.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetSpecialistDoctorInDept: IRequest<ApiResultResponse<List<TemplateDoctor>>>
    {
        public int DepartmentId { get; set; }

        public GetSpecialistDoctorInDept(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
