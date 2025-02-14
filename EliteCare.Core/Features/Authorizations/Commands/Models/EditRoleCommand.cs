using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authorizations.Commands.Models
{
    public class EditRoleCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string roleName { get; set; } = null!;
    }
}
