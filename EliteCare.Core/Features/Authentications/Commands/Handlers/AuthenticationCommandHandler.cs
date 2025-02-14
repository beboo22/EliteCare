using AutoMapper;
using EliteCare.Core.Features.Authentications.Commands.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EliteCare.Core.Features.Authentications.Commands.Handlers
{
    public class AuthenticationCommandHandler : IRequestHandler<SignInCommand, ApiResponse>,
        IRequestHandler<RefreshTokenCommand, ApiResponse>,
        IRequestHandler<SignUpCommand, ApiResponse>
    {
        #region Fileds
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _cusAuthenticationService;
        #endregion

        #region Constructors
        public AuthenticationCommandHandler(UserManager<IdentityUser<int>> userManager,
            SignInManager<IdentityUser<int>> signInManager, IMapper mapper, IAuthenticationService cusAuthenticationService)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
            _mapper = mapper;
            _cusAuthenticationService = cusAuthenticationService;
        }

        public async Task<ApiResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                    return new ApiResponse(404,"User with this username not found!");

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
                return new ApiResponse(500,ex.Message);
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
                var user = await _userManager.FindByNameAsync(request.signUp.UserName);
                if (user is not null)
                    return new ApiResponse(404, "UserName is duplicated");



                var signUpres =  await _userManager.CreateAsync(new IdentityUser<int>()
                {
                    UserName = request.signUp.UserName,
                    Email = request.signUp.Email
                },request.signUp.Password);

                if(signUpres.Succeeded)
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
        #endregion

    }
}
