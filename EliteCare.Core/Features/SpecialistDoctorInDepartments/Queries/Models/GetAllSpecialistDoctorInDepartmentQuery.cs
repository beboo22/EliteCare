using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartments.Queries.Models
{
    public class GetAllSpecialistDoctorInDepartmentQuery : IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public GetAllSpecialistDoctorInDepartmentQuery(int id)
        {
            Id = id;
        }
    }
}
