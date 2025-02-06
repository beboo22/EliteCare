using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Models
{
    public class DeleteSpecialistDoctorCommand : IRequest<ApiResponse>
    {
        public int DoctorID { get; set; }

        public DeleteSpecialistDoctorCommand(int doctorID)
        {
            DoctorID = doctorID;
        }
    }
}
