using EliteCare.Data.ServiceAbstract;
using EliteCare.Service.BaseResponse;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System.Security.Claims;
using System.Text;

namespace EliteCare.Service.impelementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        public IConfiguration _Config { get; }
        public AuthenticationService(UserManager<IdentityUser<int>> userManager, ILogger<AuthenticationService> logger, IConfiguration config)
        {
            _userManager = userManager;
            _logger = logger;
            _Config = config;
        }

        //private readonly JwtSettings _jwtSettings;
        //private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ILogger<AuthenticationService> _logger;


        //public Task<JwtAuthResponse> GetRefreshToken(IdentityUser<int> user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public JwtSecurityToken ReadJwtToken(string accessToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshTken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> ValidateToken(string accessToken)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<JwtAuthResponse> GetJwtToken(IdentityUser<int> _user)
        {
            //create privet Claims
            var Authclaims = new List<Claim>(){
                new Claim(ClaimTypes.Name,_user.UserName),
                new Claim(ClaimTypes.Email, _user.Email)
            };
            //Add Role
            var UserRole = await _userManager.GetRolesAsync(_user);
            foreach (var role in UserRole)
            {
                Authclaims.Add(new Claim(ClaimTypes.Role, role));
            }


            // create Security key

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Config["Jwt:Authkey"] ?? string.Empty));

            // create Token 


            var Token = new JwtSecurityToken
                (
                audience: _Config["Jwt:VaildAudience"],
                issuer: _Config["Jwt:validIssuer"],
                expires: DateTime.Now.AddDays(double.Parse(_Config["Jwt:validationDay"] ?? "0")),
                claims: Authclaims,
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                );
            string res = new JwtSecurityTokenHandler().WriteToken(Token);
            return new JwtAuthResponse(200, res);


        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("EliteCare", "mt557829@gmail.com"));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = subject;
            email.Body = new TextPart("plain") { Text = body };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls); // ✅ Recommended
                                                                                                // OR
                //await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect); // ✅ Alternative

                //await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("mt557829@gmail.com", "qviiiincdfuumkcg");
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
        }
    }
}
