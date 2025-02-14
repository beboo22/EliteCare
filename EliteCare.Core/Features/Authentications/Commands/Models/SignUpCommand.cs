using EliteCare.Core.Dtos;
using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authentications.Commands.Models
{
    public class SignUpCommand:IRequest<ApiResponse>
    {
        public SignUpDto signUp { get; set; }

        public SignUpCommand(SignUpDto signUp)
        {
            this.signUp = signUp;
        }
    }
}
