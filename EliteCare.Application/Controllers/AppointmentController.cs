using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Appointments.Commands.Models;
using EliteCare.Core.Features.Appointments.Commands.Models;
using EliteCare.Core.Features.Appointments.Queries.Models;
using EliteCare.Core.Mapping;
using EliteCare.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Presentation.Controllers
{
    public class AppointmentController : BaseController
    {
        [HttpPost("AddAppointment")]
        //[SaveOperationData<Appointment>]
        public async Task<IActionResult> AddAppointment([FromBody] AddAppointmentDtos appointmentDtos)
        {
            //return Ok(new ApiResultResponse<string>(200, "Appointment added successfully"));

            var responce = await Mediator.Send(new AddAppointmentCommand(appointmentDtos));
            return Ok(responce);
        }

        [HttpPut("UpdateAppointment")]
        //[SaveOperationData<Appointment>]
        public async Task<IActionResult> UpdateAppointment([FromBody] UpdateAppointmentDtos appointmentDtos)
        {
            var responce = await Mediator.Send(new UpdateAppointmentCommand(appointmentDtos));
            return Ok(responce);
        }

        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment([FromQuery]int AppointmentId)
        {
            var responce = await Mediator.Send(new DeleteAppointmentCommand(AppointmentId));
            return Ok(responce);
        }

        [HttpGet("GetAllAppointment")]
        public async Task<IActionResult> GetAllAppointment()
        {
            var respnse = await Mediator.Send(new GetAllAppointmentQuery());
            return Ok(respnse);
        }
        [HttpGet("GetAppointmentById")]
        public async Task<IActionResult> GetAppointmentById([FromQuery]int id)
        {
            var respnse = await Mediator.Send(new GetByIdAppointmentQuery(id));
            return Ok(respnse);
        }
    }
}
