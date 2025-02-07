using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.patients.Queries.Models
{
    public class GetByEmailPatientQuery:IRequest<ApiResponse>
    {
        public string email { get; set; }

        public GetByEmailPatientQuery(string email)
        {
            this.email = email;
        }
    }
}
