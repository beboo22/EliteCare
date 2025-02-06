using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Commands.Models
{
    public class DeleteReceptionistsCommand: IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public DeleteReceptionistsCommand(int id)
        {
            Id = id;
        }
    }
}
