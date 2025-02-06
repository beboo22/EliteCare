using AutoMapper;
using EliteCare.Core.Features.Departments.Queries.Models;
using EliteCare.Core.Features.Departments.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler:IRequestHandler<GetAllDeprtmentQuery,ApiResponse>,
                                        IRequestHandler<GetByIdDepartmentQuery,ApiResponse>
    {
        public IDepartmentService depServ { get; set; }
        public IMapper mapper { get; set; }

        public DepartmentQueryHandler(IDepartmentService depServ, IMapper mapper)
        {
            this.depServ = depServ;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(GetAllDeprtmentQuery request, CancellationToken cancellationToken)
        {
            var items = await depServ.GetAllDepartment();
            var mapped = mapper.Map<List<TemplateDepartment>>(items);
            return items.Any() is true ? new ApiResultResponse<List<TemplateDepartment>>(200, mapped) :
                                         new ApiResponse(404);
        }

        public async Task<ApiResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            var items = await depServ.GetDepartmentByIdSpec(request.DepId);
            var mapped = mapper.Map<TemplateDepartment>(items);
            return items is not null ? new ApiResultResponse<TemplateDepartment>(200, mapped) :
                                         new ApiResponse(404);
        }
    }
}
