using EliteCare.Service.BaseResponse;
using MediatR;

namespace EliteCare.Core.Features.Receptionists.Commands.Models
{
    public class DeleteReceptionistsCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }

        public DeleteReceptionistsCommand(int id)
        {
            Id = id;
        }
    }
}
