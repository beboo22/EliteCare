using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System.Text.Json;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IBookingService
    {
        Task<ApiResponse> Book(Bill bill);
        Task<ApiResponse> HandlePaymobCallback(JsonElement payload);
    }
}
