using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Security.Claims;
using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Authentications.Commands.Models;
using EliteCare.Core.Features.Authorizations.Commands.Models;
using EliteCare.Core.Features.Authorizations.Queries.Models;

namespace EliteCare.Presentation.Controllers
{
    public class AccountController : BaseController
    {

        [HttpPost("Sign-In")]
        public async Task<IActionResult> SignIn([FromForm] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("Sign-Up")]
        public async Task<IActionResult> SignUp([FromForm] SignUpDto command)
        {
            var response = await Mediator.Send(new SignUpCommand(command));
            return Ok(response);
        }
        //mt18724860@gmail.com
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] EmailRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("logOut")]
        public async Task<IActionResult> logOutAsync()
        {
           var res = await Mediator.Send(new LogoutCommand());
            return Ok(res);
        }
        [HttpGet("List")]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRoleListQuery());
            return Ok(response);
        }

        [HttpGet("Role/{Id:int}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery(Id));
            return Ok(response);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(Id));
            return Ok(response);
        }
        [HttpPut("Update-User-Roles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] EditUserRolesCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }


    }
}
