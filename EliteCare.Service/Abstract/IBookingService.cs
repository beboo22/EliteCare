using EliteCare.Data.Entities;
using EliteCare.Service.BaseResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IBookingService
    {
        Task<ApiResponse> Book(Bill bill);
        Task<ApiResponse> HandlePaymobCallback(JsonElement payload);
    }
}
