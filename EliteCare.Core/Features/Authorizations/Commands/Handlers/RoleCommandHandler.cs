using EliteCare.Core.Features.Authorizations.Commands.Models;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EliteCare.Core.Features.Authorizations.Commands.Handlers
{
    public class RoleCommandHandler : IRequestHandler<AddRoleCommand, ApiResponse>,
        IRequestHandler<EditRoleCommand, ApiResponse>,
        IRequestHandler<DeleteRoleCommand, ApiResponse>,
        IRequestHandler<EditUserRolesCommand,ApiResponse>
    {
        private readonly IAuthorizationService _authorizationService;
        //public UserManager _userManger { get; set; }


        public RoleCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task<ApiResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isExist = await _authorizationService.IsRoleNameExist(request.roleName);
                if (isExist)
                    return new ApiResponse(200,"this role name is already exist.");

                var IsAdded = await _authorizationService.AddRoleAsync(request.roleName);

                if (!IsAdded) return new ApiResponse(500, "Added operation failed.");

                return new ApiResponse(200, "Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500,ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var isExist = await _authorizationService.IsRoleNameExist(request.roleName);
                if (isExist)
                    return new ApiResponse(200, "this role name is already exist.");


                var IsEdited = await _authorizationService.EditRoleById(request.Id, request.roleName);

                if (!IsEdited) return new ApiResponse(500,"Edited operation failed.");

                return  new ApiResponse(200,"Edited Operation Successfully.");
            }
            catch (Exception ex)
            {
                return  new ApiResponse(500,ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = await _authorizationService.GetRoleByID(request.Id);
                if (role == null)
                    return new ApiResponse(404,"role with this id not found!");

                var IsDeleted = await _authorizationService.DeleteRoleById(role);
                if (!IsDeleted)
                    return new ApiResponse(500,"Deleted Operation Failed.");

                return new ApiResponse(200,"Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(500,ex.Message);
            }
        }

        public async Task<ApiResponse> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var result = await _authorizationService.UpdateUserRoles(request.UserId,request.roles);
                
                return result;
            }
            catch (Exception ex)
            {
                return new ApiResponse(500,ex.Message);
            }
        }
    }
}
