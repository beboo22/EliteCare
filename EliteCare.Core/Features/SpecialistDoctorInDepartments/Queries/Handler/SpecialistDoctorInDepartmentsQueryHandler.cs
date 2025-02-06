using AutoMapper;
using EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Models;
using EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Validations;
using EliteCare.Core.Features.SpecialistDoctorInDepartments.Queries.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartments.Queries.Handler
{
    internal class SpecialistDoctorInDepartmentsQueryHandler : IRequestHandler<GetspecialistInAllQuery, ApiResponse>, 
                                                               IRequestHandler<GetAllSpecialistDoctorInDepartmentQuery, ApiResponse>
                                                                    
    {
        public ISpecialistDoctorInDepartmentService specialistServ { get; set; }
        IMapper mapper { get; set; }

        public SpecialistDoctorInDepartmentsQueryHandler(ISpecialistDoctorInDepartmentService specialist, IMapper mapper)
        {
            this.specialistServ = specialist;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetspecialistInAllQuery request, CancellationToken cancellationToken)
        {
            var specialists = await specialistServ.GetAll();

            var mappedspecialists = mapper.Map<List<TemplateSpecialist>>(specialists);

            return specialists.Any() is true ? new ApiResultResponse<List<TemplateSpecialist>>(200, mappedspecialists):new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetAllSpecialistDoctorInDepartmentQuery request, CancellationToken cancellationToken)
        {
            var specialists = await specialistServ.GetAllSpecialistDoctorInDepartment(request.Id);

            var mappedspecialists = mapper.Map<List<TemplateSpecialist>>(specialists);

            return specialists.Any() is true ? new ApiResultResponse<List<TemplateSpecialist>>(200, mappedspecialists) : new ApiResponse(404);
        }
    }
}
