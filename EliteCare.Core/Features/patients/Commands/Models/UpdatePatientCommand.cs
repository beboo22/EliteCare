using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Commands.Models
{
    public class UpdatePatientCommand : IRequest<ApiResponse>
    {
        public UpdatePatientDto patientDto { get; set; }

        public UpdatePatientCommand(UpdatePatientDto patientDto)
        {
            this.patientDto = patientDto;
        }
    }
}
