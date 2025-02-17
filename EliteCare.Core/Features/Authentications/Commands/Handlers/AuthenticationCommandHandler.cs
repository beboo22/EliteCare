using AutoMapper;
using EliteCare.Core.Features.Authentications.Commands.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;

namespace EliteCare.Core.Features.Authentications.Commands.Handlers
{
    public class AuthenticationCommandHandler : IRequestHandler<SignInCommand, ApiResponse>,
        IRequestHandler<RefreshTokenCommand, ApiResponse>,
        IRequestHandler<EmailRequest, ApiResponse>,
        IRequestHandler<SignInWithGoogleRequest, ApiResponse>,
        IRequestHandler<SignInWithFacebookRequest, ApiResponse>,
        IRequestHandler<SignUpCommand, ApiResponse>,
        IRequestHandler<LogoutCommand, ApiResponse>

    {
        #region Fileds
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly IMapper _mapper;
        private readonly EliteCare.Service.Abstract.IAuthenticationService _cusAuthenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructors
        public AuthenticationCommandHandler(UserManager<IdentityUser<int>> userManager,
            SignInManager<IdentityUser<int>> signInManager, IMapper mapper, EliteCare.Service.Abstract.IAuthenticationService cusAuthenticationService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _cusAuthenticationService = cusAuthenticationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                    return new ApiResponse(404, "User with this username not found!");

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!signInResult.Succeeded)
                {
                    return new ApiResponse(400, "Password is't correct.");
                }

                var accessToken = await _cusAuthenticationService.GetJwtToken(user);
                return accessToken;
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }
        }

        public Task<ApiResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var normalizedUserName = _userManager.NormalizeName(request.signUp.UserName);
                var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName);
                if (existingUser is not null)
                    return new ApiResponse(404, "UserName is duplicated");



                var signUpres = await _userManager.CreateAsync(new IdentityUser<int>()
                {
                    UserName = request.signUp.UserName,
                    Email = request.signUp.Email,

                }, request.signUp.Password);

                if (signUpres.Succeeded)
                {

                    var accessToken = await _cusAuthenticationService.GetJwtToken(new IdentityUser<int>()
                    {
                        UserName = request.signUp.UserName,
                        Email = request.signUp.Email
                    });
                    return accessToken;
                }
                return new ApiResponse(500, "Error While Creating User");

            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(EmailRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    return new ApiResponse(404, "User not found.");

                // Generate Reset Token
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Generate Reset Link
                var resetLink = $"https://yourfrontend.com/reset-password?email={request.Email}&token={Uri.EscapeDataString(token)}";

                // Send Email
                string emailBody = $"Click the link to reset your password: <a href='{HtmlEncoder.Default.Encode(resetLink)}'>Reset Password</a>";



                await _cusAuthenticationService.SendEmailAsync(request.Email, "Password Reset", emailBody);
                return new ApiResponse(200);
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }


        }

        public async Task<ApiResponse> Handle(SignInWithGoogleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var properties = new AuthenticationProperties { RedirectUri = request.RedirectUrl };
                await _httpContextAccessor.HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
                return new ApiResponse(200, "Challenge initiated");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(SignInWithFacebookRequest request, CancellationToken cancellationToken)
        {

            var properties = new AuthenticationProperties { RedirectUri = request.RedirectUrl };
            try
            {

                string res = _httpContextAccessor.HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, properties).ToString();
                return res is not null ? new ApiResultResponse<string>(200, res) : new ApiResponse(401);
            }
            catch (Exception ex)
            {
                return new ApiResponse(500, ex.Message);
            }


        }

        public async Task<ApiResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _signInManager.SignOutAsync();

                return new ApiResponse(200);
            }
            catch (Exception ex) { 
            return new ApiResponse(500, ex.Message);
            }

        }
        #endregion

    }
}
