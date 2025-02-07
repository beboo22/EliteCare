using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Receptionists.Queries.Models
{
    public class GetByIdReceptionistQuery : IRequest<ApiResponse>
    {
        public int id { get; set; }

        public GetByIdReceptionistQuery(int id)
        {
            this.id = id;
        }
    }
}
