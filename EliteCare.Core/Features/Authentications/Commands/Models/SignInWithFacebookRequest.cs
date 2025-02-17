using EliteCare.Service.BaseResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authentications.Commands.Models
{
    public class SignInWithFacebookRequest : IRequest<ApiResponse>
    {
        public string RedirectUrl { get; set; }

        public SignInWithFacebookRequest(string redirectUrl)
        {
            RedirectUrl = redirectUrl;
        }
    }
}
