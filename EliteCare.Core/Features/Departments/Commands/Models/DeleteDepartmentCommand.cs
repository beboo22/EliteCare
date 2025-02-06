using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommand:IRequest<ApiResponse>
    {
        public int DepId { get; set; }

        public DeleteDepartmentCommand(int depId)
        {
            DepId = depId;
        }
    }
}
