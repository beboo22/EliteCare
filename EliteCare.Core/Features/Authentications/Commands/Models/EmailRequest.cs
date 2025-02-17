using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authentications.Commands.Models
{
    public class EmailRequest : IRequest<ApiResponse>
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
