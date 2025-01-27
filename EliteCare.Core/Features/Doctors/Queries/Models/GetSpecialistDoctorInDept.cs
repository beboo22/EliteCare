using EliteCare.Core.BaseResponse;
using EliteCare.Core.Features.Doctors.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
