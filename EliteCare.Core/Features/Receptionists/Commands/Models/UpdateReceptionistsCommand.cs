using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Commands.Models
{
    public class UpdateReceptionistsCommand : IRequest<ApiResponse>
    {
        public UpdateReceptionistDto receptionistDto { get; set; }

        public UpdateReceptionistsCommand(UpdateReceptionistDto receptionistDto)
        {
            this.receptionistDto = receptionistDto;
        }
    }
}
