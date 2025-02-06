using AutoMapper;
using EliteCare.Core.Features.Departments.Commands.Models;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, ApiResponse>,
                                              IRequestHandler<UpdateDepartmentCommand, ApiResponse>,
                                              IRequestHandler<DeleteDepartmentCommand, ApiResponse>
    {
        public IDepartmentService depServ { get; set; }
        public IMapper mapper { get; set; }

        public DepartmentCommandHandler(IDepartmentService depServ, IMapper mapper)
        {
            this.depServ = depServ;
            this.mapper = mapper;
        }

        public Task<ApiResponse> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            var mappedDep = mapper.Map<Department>(request.departmentDto);
            var check = depServ.AddDepartmentAsync(mappedDep);
            return check;
        }

        public async Task<ApiResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var mappedDep = mapper.Map<Department>(request.departmentDto);
            var check = depServ.UpdateDepartmentAsync(mappedDep);
            return check;
        }

        public async Task<ApiResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var check = await depServ.DeleteDepartmentAsync(request.DepId);
            return check;
        }
    }
}
