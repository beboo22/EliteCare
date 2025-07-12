using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Departments.Commands.Models;
using EliteCare.Core.Features.Departments.Queries.Models;
using EliteCare.Core.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Presentation.Controllers
{
    public class DepartmentController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var res = await Mediator.Send(new GetAllDeprtmentQuery());
            return Ok(res);
        }

        [HttpGet("GetDepartmentById/{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var res = await Mediator.Send(new GetByIdDepartmentQuery(id));
            return Ok(res);
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody]AddDepartmentDto  departmentDto)
        {
            var res = await Mediator.Send(new AddDepartmentCommand(departmentDto));
            return Ok(res);
        }
        
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody]UpdateDepartmentDto  departmentDto)
        {
            var res = await Mediator.Send(new UpdateDepartmentCommand(departmentDto));
            return Ok(res);
        }
        
        
        [HttpDelete("DeleteDepartment/{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int  id)
        {
            var res = await Mediator.Send(new DeleteDepartmentCommand(id));
            return Ok(res);
        }









    }
}
