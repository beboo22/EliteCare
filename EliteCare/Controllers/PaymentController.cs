using EliteCare.Core.Dtos;
using EliteCare.Core.Features.Bills.Commands.Models;
using EliteCare.Core.Features.patients.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EliteCare.Api.Controllers
{
    public class PaymentController : BaseController
    {
        [HttpPost("CreatBill")]
        //[SaveOperationData<Doctor>]
        public async Task<IActionResult> CreatBill([FromBody] AddBillDto addBillDto)
        {
            //return Ok(new ApiResultResponse<string>(200, "Doctor added successfully"));

            var responce = await Mediator.Send(new AddBillCommand(addBillDto));
            return Ok(responce);
        }



        [HttpGet("paymob-callback")]
        public async Task<IActionResult> PaymobCallback([FromBody] JsonElement payload)
        {
            var response = await Mediator.Send(new CallBackCommand(payload));
            return Ok(response);
        }



    }
}
