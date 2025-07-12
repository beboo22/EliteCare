using EliteCare.Service.BaseResponse;
using Microsoft.AspNetCore.Identity;

namespace EliteCare.Data.ServiceAbstract
{
    public interface IAuthenticationService
    {
        Task<JwtAuthResponse> GetJwtToken(IdentityUser<int> user);
        Task SendEmailAsync(string recipientEmail, string subject, string body);
        //JwtSecurityToken ReadJwtToken(string accessToken);
        //Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshTken);
        //Task<JwtAuthResponse> GetRefreshToken(IdentityUser<int> user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        //Task<string> ValidateToken(string accessToken);
    }
}
