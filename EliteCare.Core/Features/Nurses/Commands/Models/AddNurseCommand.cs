using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Nurses.Commands.Models
{
    public class AddNurseCommand : IRequest<ApiResponse>
    {
        public AddNurseDto addNurse { get; set; }

        public AddNurseCommand(AddNurseDto addNurse)
        {
            this.addNurse = addNurse;
        }
    }
}
