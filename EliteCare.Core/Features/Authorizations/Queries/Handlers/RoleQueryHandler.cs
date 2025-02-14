using AutoMapper;
using EliteCare.Core.Features.Authorizations.Queries.Models;
using EliteCare.Core.Features.Authorizations.Queries.Response;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Core.Features.Authorizations.Queries.Handlers
{
    public class RoleQueryHandler: IRequestHandler<GetRoleByIdQuery, ApiResponse>,
        IRequestHandler<GetRoleListQuery, ApiResponse>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser<int>> _userManager;
        
        public RoleQueryHandler(IAuthorizationService authorizationService,
            IMapper mapper, UserManager<IdentityUser<int>> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ApiResponse> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _authorizationService.GetRoleByID(request.Id);
                if (role == null)
                    return new ApiResponse(404,"role with this Id not Found!");

                var roleMapper = _mapper.Map<TemplateRole>(role);
                return new ApiResultResponse<TemplateRole>(200,roleMapper);
            }
            catch (Exception ex)
            {
                return new ApiResponse(500,ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await _authorizationService.GetRoleListAsync();
                if (roles == null)
                {
                    return new ApiResponse(404,"Not Found Roles");
                }

                var rolesMapper = _mapper.Map<List<TemplateRole>>(roles);
                return new ApiResultResponse<List<TemplateRole>>(200,rolesMapper);
            }
            catch (Exception ex)
            {
                return new ApiResponse(500,ex.Message);
            }
        }
    }
}
