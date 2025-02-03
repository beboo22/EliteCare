using EliteCare.Core.BaseResponse;
using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Doctors.Commands.Models;
using EliteCare.Core.Features.Doctors.Queries.Models;
using EliteCare.Core.Mapping;
using EliteCare.Data.Entities;
using EliteCare.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EliteCare.Api.Controllers
{

    public class DoctorController : BaseController
    {
        public IDoctorService DocServ { get; set; }
        public DoctorController(IDoctorService docServ)
        {
            DocServ = docServ;
        }


        #region Add,Update,Delete
        [HttpPost("AddDoctor")]
        [SaveOperationData<Doctor>]
        public async Task<IActionResult> AddDoctor([FromBody]AddDoctorDtos doctorDtos)
        {
            //return Ok(new ApiResultResponse<string>(200, "Doctor added successfully"));

            var responce = await Mediator.Send(new AddDoctorCommand(doctorDtos));
            return Ok(responce);
        }

        [HttpPut("UpdateDoctor")]
        [SaveOperationData<Doctor>]
        public async Task<IActionResult> UpdateDoctor([FromBody]UpdateDoctorDtos doctorDtos)
        {
            var responce = await Mediator.Send(new UpdateDoctorCommand(doctorDtos));
            return Ok(responce);
        }

        [HttpDelete("DeleteDoctor/{doctorId:int}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            var responce = await Mediator.Send(new DeleteDoctorCommand(doctorId));
            return Ok(responce);
        }


        [HttpPost("AddSpecialistDoctor")]
        public async Task<IActionResult> AddSpecialistDoctor([FromBody] AddSpecialistDoctorDtos doctorDtos)
        {
            var responce = await Mediator.Send(new AddSpecialistDoctorCommand(doctorDtos));
            return Ok(responce);
        }




        #endregion



        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> GetAllDoctor()
        {
            var respnse = await Mediator.Send(new GetAllDoctor());
            return Ok(respnse);
        }
        [HttpGet("GetDoctorById/{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var respnse = await Mediator.Send(new GetDoctorById(id));
            return Ok(respnse);
        }


        [HttpGet("GetDoctorByEmail/{email}")]
        public async Task<IActionResult> GetDoctorByEmail([EmailAddress]string email)
        {
            var respnse = await Mediator.Send(new GetDoctorByEmail(email));
            return Ok(respnse);
        }

        [HttpGet("GetDoctorForDept/{departmentId:int}")]
        public async Task<IActionResult> GetDoctorForDept(int departmentId)
        {
            var respnse = await Mediator.Send(new GetDoctorsForDept(departmentId));
            return Ok(respnse);
        }

        [HttpGet("SpecialistDoctorInDepartment/{departmentId:int}")]
        public async Task<IActionResult> SpecialistDoctorInDepartment(int departmentId)
        {
            var respnse = await Mediator.Send(new GetSpecialistDoctorInDept(departmentId));
            return Ok(respnse);
        }
    }
}
