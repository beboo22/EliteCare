using EliteCare.Service.BaseResponse;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Bills.Commands.Models
{
    public class CallBackCommand : IRequest<ApiResponse>
    {
        public JsonElement element {  get; set; }

        public CallBackCommand(JsonElement element)
        {
            this.element = element;
        }
    }
}
