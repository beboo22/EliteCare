using EliteCare.Core.Dtos;
using EliteCare.Core.Features.patients.Commands.Models;
using EliteCare.Core.Features.patients.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EliteCare.Api.Controllers
{
    public class PatientController : BaseController
    {

        #region Add,Update,Delete
        [HttpPost("AddPatient")]
        //[SaveOperationData<Doctor>]
        public async Task<IActionResult> AddPatient([FromBody] AddPatientDto PatientDto)
        {

            var responce = await Mediator.Send(new AddPatientCommand(PatientDto));
            return Ok(responce);
        }

        [HttpPut("UpdatePatient")]
        //[SaveOperationData<Doctor>]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientDto PatientDto)
        {
            var responce = await Mediator.Send(new UpdatePatientCommand(PatientDto));
            return Ok(responce);
        }

        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient([FromQuery]int patientID)
        {
            var responce = await Mediator.Send(new DeletePatientCommand(patientID));
            return Ok(responce);
        }
        #endregion



        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var respnse = await Mediator.Send(new GetAllPatientQuery());
            return Ok(respnse);
        }

        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatientById([FromQuery]int id)
        {
            var respnse = await Mediator.Send(new GetByIdPatientQuery(id));
            return Ok(respnse);
        }

        [HttpGet("GetPatientByEmail")]
        public async Task<IActionResult> GetPatientByEmail([FromQuery][EmailAddress] string email)
        {
            var respnse = await Mediator.Send(new GetByEmailPatientQuery(email));
            return Ok(respnse);
        }


        [HttpGet("GetAllAppointmentForPatient")]
        public async Task<IActionResult> GetAppointmentForPatient([FromQuery]int id)
        {
            var respnse = await Mediator.Send(new GetAllAppointmentForPatient(id));
            return Ok(respnse);
        }


    }
}
