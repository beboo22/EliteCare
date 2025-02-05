using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Nurse.Queries.Models;
using EliteCare.Core.Features.Nurses.Commands.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EliteCare.Api.Controllers
{
    public class NurseController : BaseController
    {
        #region R Opreation

        [HttpGet("GetAllNurses")]
        public async Task<IActionResult> GetAllNurses()
        {
            var nurses = await Mediator.Send(new GetAllNurse());
            return Ok(nurses);
        }

        [HttpGet("GetNurseById/{id:int}")]
        public async Task<IActionResult> GetNurseById(int id)
        {
            var nurses = await Mediator.Send(new GetNurseById(id));
            return Ok(nurses);
        }

        [HttpGet("GetNurseByEmail")]
        public async Task<IActionResult> GetNurseByEmail([FromQuery][EmailAddress] string Email)
        {
            var nurses = await Mediator.Send(new GetNurseByEmail(Email));
            return Ok(nurses);
        }

        [HttpGet("GetNurseForRoom/{RoomId:int}")]
        public async Task<IActionResult> GetNurseForRoom(int RoomId)
        {
            var nurses = await Mediator.Send(new GetNursesGovernRoom(RoomId));
            return Ok(nurses);
        }


        #endregion

        #region CUD Operation

        [HttpPost("AddNurse")]
        public async Task<IActionResult> AddNurse([FromBody] AddNurseDto addNurseDto)
        {
            var res = await Mediator.Send(new AddNurseCommand(addNurseDto));
            return Ok(res);
        }

        [HttpPut("UpdateNurse")]
        public async Task<IActionResult> UpdateNurse([FromBody] UpdateNurseDto updateNurseDto)
        {
            var res = await Mediator.Send(new UpdateNurseCommand(updateNurseDto));
            return Ok(res);
        }
        [HttpDelete("DeleteNurse")]
        public async Task<IActionResult> UpdateNurse([FromBody] int id)
        {
            var res = await Mediator.Send(new DeleteNurseCommand(id));
            return Ok(res);
        } 
        #endregion
    }
}
