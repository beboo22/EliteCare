using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Authentications.Commands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Api.Controllers
{
    public class AuthenticationController : BaseController
    {

        [HttpPost("Sign-In")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("Sign-Up")]
        public async Task<IActionResult> SignIn([FromForm] SignUpDto command)
        {
            var response = await Mediator.Send(new SignUpCommand(command));
            return Ok(response);
        }


    }
}
