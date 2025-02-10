using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Bills.Commands.Models
{
    public class AddBillCommand : IRequest<ApiResponse>
    {
        public AddBillDto billDto { get; set; }

        public AddBillCommand(AddBillDto billDto)
        {
            this.billDto = billDto;
        }
    }
}
