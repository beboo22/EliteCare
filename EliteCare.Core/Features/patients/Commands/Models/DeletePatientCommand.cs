using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Commands.Models
{
    public class DeletePatientCommand: IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public DeletePatientCommand(int id)
        {
            Id = id;
        }
    }
}
