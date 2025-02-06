using EliteCare.Core.Features.Nurse.Queries.Response;
using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Nurse.Queries.Models
{
    public class GetNurseById : IRequest<ApiResponse>
    {
        public GetNurseById(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
