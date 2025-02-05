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
    public class UpdateNurseCommand : IRequest<ApiResponse>
    {
        public UpdateNurseDto updateNurse { get; set; }

        public UpdateNurseCommand(UpdateNurseDto updateNurse)
        {
            this.updateNurse = updateNurse;
        }
    }
}
