using EliteCare.Core.Features.Authorizations.Commands.Models;
using EliteCare.Core.Features.Authorizations.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Api.Controllers
{
    public class AuthorzationController : BaseController
    {
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

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{Id:int}")]
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
