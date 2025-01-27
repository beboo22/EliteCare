using EliteCare.Core.Features.Doctors.Commands.Models;
using EliteCare.Core.Features.Doctors.Queries.Models;
using EliteCare.Core.Mapping;
using EliteCare.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {
        public IDoctorService DocServ { get; set; }
        public DoctorController(IDoctorService docServ)
        {
            DocServ = docServ;
        }


        #region Add,Update,Delete

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDtos doctorDtos)
        {
            var responce = await Mediator.Send(new AddDoctorCommand(doctorDtos));
            return Ok(responce);
        }

        [HttpPut("UpdateDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] DoctorDtos doctorDtos)
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


        #endregion



        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> GetAllDoctor()
        {
            var respnse = Mediator.Send(new GetAllDoctor());
            return Ok(respnse);
        }
        [HttpGet("GetDoctorById/{id:int}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var respnse = Mediator.Send(new GetDoctorById(id));
            return Ok(respnse);
        }


        [HttpGet("GetDoctorByEmail/{Email:alpha}")]
        public async Task<IActionResult> GetDoctorByEmail(string email)
        {
            var respnse = Mediator.Send(new GetDoctorByEmail(email));
            return Ok(respnse);
        }

        [HttpGet("GetDoctorForDept/{departmentId:int}")]
        public async Task<IActionResult> GetDoctorForDept(int departmentId)
        {
            var respnse = Mediator.Send(new GetDoctorsForDept(departmentId));
            return Ok(respnse);
        }

        [HttpGet("SpecialistDoctorInDepartment/{departmentId:int}")]
        public async Task<IActionResult> SpecialistDoctorInDepartment(int departmentId)
        {
            var respnse = Mediator.Send(new GetSpecialistDoctorInDept(departmentId));
            return Ok(respnse);
        }
    }
}
