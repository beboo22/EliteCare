using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Models
{
    public class GetNursesGovernRoom:IRequest<ApiResultResponse<List<TemplateNurse>>>
    {
        public int RoomId { get; set; }

        public GetNursesGovernRoom(int roomId)
        {
            RoomId = roomId;
        }
    }
}
