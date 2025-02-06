using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Departments.Commands.Models
{
    public class UpdateDepartmentCommand : IRequest<ApiResponse>
    {
        public UpdateDepartmentDto departmentDto { get; set; }

        public UpdateDepartmentCommand(UpdateDepartmentDto departmentDto)
        {
            this.departmentDto = departmentDto;
        }
    }
}
