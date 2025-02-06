using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Models
{
    public class GetByEmailReceptionistQuery:IRequest<ApiResponse>
    {
        public string email { get; set; }

        public GetByEmailReceptionistQuery(string email)
        {
            this.email = email;
        }
    }
}
