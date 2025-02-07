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
    public class AddPatientCommand : IRequest<ApiResponse>
    {
        public AddPatientDto patientDto { get; set; }

        public AddPatientCommand(AddPatientDto patientDto)
        {
            this.patientDto = patientDto;
        }
    }
}
