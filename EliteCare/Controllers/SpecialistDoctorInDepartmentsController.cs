using EliteCare.Core.Dtos;
using EliteCare.Core.Features.SpecialistDoctorInDepartment.Queries.Models;
using EliteCare.Core.Features.SpecialistDoctorInDepartments.Commands.Models;
using EliteCare.Core.Features.SpecialistDoctorInDepartments.Queries.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistDoctorInDepartmentsController : BaseController
    {
        #region CUD Operations

        [HttpPost("AddSpecialist")]
        public async Task<IActionResult> AddSpecialist(AddSpecialistDoctorDtos addSpecialist)
        {
            var res = await Mediator.Send(new AddSpecialistDoctorCommand(addSpecialist));
            return Ok(res);
        }
        [HttpPut("UpdateSpecialist")]
        public async Task<IActionResult> UpdateSpecialist(AddSpecialistDoctorDtos addSpecialist)
        {
            var res = await Mediator.Send(new UpdateSpecialistDoctorCommand(addSpecialist));
            return Ok(res);
        }

        [HttpDelete("DeleteSpecialist/{DoctorId:int}")]
        public async Task<IActionResult> UpdateSpecialist(int DoctorId)
        {
            var res = await Mediator.Send(new DeleteSpecialistDoctorCommand(DoctorId));
            return Ok(res);
        }
        #endregion

        #region R Operations

        [HttpGet("GetSpecialistDoctorAllDepartment")]
        public async Task<IActionResult> GetSpecialistDoctorAllDepartment()
        {
            var res = await Mediator.Send(new GetspecialistInAllQuery());
            return Ok(res);
        }
        [HttpGet("GetAllSpecialistDoctorinDepartment/{DepId:int}")]
        public async Task<IActionResult> GetAllSpecialistDoctorinDepartment(int DepId)
        {
            var res = await Mediator.Send(new GetAllSpecialistDoctorInDepartmentQuery(DepId));
            return Ok(res);
        }


        #endregion

    }
}
