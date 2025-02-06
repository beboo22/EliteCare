using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Doctors.Commands.Models;
using EliteCare.Core.Features.Doctors.Queries.Models;
using EliteCare.Core.Features.Receptionists.Commands.Models;
using EliteCare.Core.Features.Receptionists.Queries.Models;
using EliteCare.Core.Mapping;
using EliteCare.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EliteCare.Api.Controllers
{
    public class ReceptionistController : BaseController
    {
        #region Add,Update,Delete
        [HttpPost("AddReceptionist")]
        [SaveOperationData<Doctor>]
        public async Task<IActionResult> AddReceptionist([FromBody] AddReceptionistDto receptionistDto)
        {
            //return Ok(new ApiResultResponse<string>(200, "Doctor added successfully"));

            var responce = await Mediator.Send(new AddReceptionistsCommand(receptionistDto));
            return Ok(responce);
        }

        [HttpPut("UpdateReceptionist")]
        [SaveOperationData<Doctor>]
        public async Task<IActionResult> UpdateReceptionist([FromBody] UpdateReceptionistDto receptionistDto)
        {
            var responce = await Mediator.Send(new UpdateReceptionistsCommand(receptionistDto));
            return Ok(responce);
        }

        [HttpDelete("DeleteReceptionist/{recepID:int}")]
        public async Task<IActionResult> DeleteReceptionist(int recepID)
        {
            var responce = await Mediator.Send(new DeleteReceptionistsCommand(recepID));
            return Ok(responce);
        }






        //[HttpPost("AddSpecialistDoctor")]
        //public async Task<IActionResult> AddSpecialistDoctor([FromBody] AddSpecialistDoctorDtos doctorDtos)
        //{
        //    var responce = await Mediator.Send(new AddSpecialistDoctorCommand(doctorDtos));
        //    return Ok(responce);
        //}




        #endregion



        [HttpGet("GetAllReceptionist")]
        public async Task<IActionResult> GetAllReceptionist()
        {
            var respnse = await Mediator.Send(new GetAllReceptionistQuery());
            return Ok(respnse);
        }
        [HttpGet("GetReceptionistById/{id:int}")]
        public async Task<IActionResult> GetReceptionistById(int id)
        {
            var respnse = await Mediator.Send(new GetByIdReceptionistQuery(id));
            return Ok(respnse);
        }


        [HttpGet("GetReceptionistByEmail/{email}")]
        public async Task<IActionResult> GetReceptionistByEmail([EmailAddress] string email)
        {
            var respnse = await Mediator.Send(new GetByEmailReceptionistQuery(email));
            return Ok(respnse);
        }
    }
}
