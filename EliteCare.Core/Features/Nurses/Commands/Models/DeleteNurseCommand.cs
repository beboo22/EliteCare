using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Nurses.Commands.Models
{
    public class DeleteNurseCommand:IRequest<ApiResponse>
    {
        public int id { get; set; }

        public DeleteNurseCommand(int id)
        {
            this.id = id;
        }
    }
}
