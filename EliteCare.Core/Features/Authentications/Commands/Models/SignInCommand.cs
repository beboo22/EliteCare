using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authentications.Commands.Models
{
    public class SignInCommand : IRequest<ApiResponse>
    {

        public string UserName { get; set; } 
        public string Password { get; set; }

        //public SignInCommand(string userName, string password)
        //{
        //    UserName = userName;
        //    Password = password;
        //}

    }
}
