using EliteCare.Core.BaseResponse;
using EliteCare.Core.Features.Doctors.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByEmail : IRequest<ApiResultResponse<TemplateDoctor>>
    {
        public GetDoctorByEmail(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}
