using EliteCare.Infrastructure.IdentityData;
using EliteCare.Service.Abstract;
using EliteCare.Service.BaseResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.impelementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fileds
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly ILogger<AuthorizationService> _logger;
        private readonly AppIdentityDbContext _dbContext;
        #endregion

        #region Constructors
        public AuthorizationService(RoleManager<IdentityRole<int>> roleManager, UserManager<IdentityUser<int>> userManager,
           ILogger<AuthorizationService> logger, AppIdentityDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
            _dbContext = dbContext;
        }
        #endregion

        #region Functions

        public async Task<bool> AddRoleAsync(string roleName)
        {
            try
            {
                var role = new IdentityRole<int>();
                role.Name = roleName.ToLower();

                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in AddRoleAsync");
                throw;
            }
        }
        public async Task<bool> EditRoleById(int Id, string roleName)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id.ToString());
                if (role == null)
                    return false;

                role.Name = roleName;
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in EditRoleById");
                throw;
            }
        }
        public async Task<bool> DeleteRoleById(IdentityRole<int> role)
        {
            try
            {
                var users = await _userManager.GetUsersInRoleAsync(role.Name!);
                if (users != null && users.Count() > 0)
                    return false;


                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in DeleteRoleById");
                throw;
            }
        }
        public async Task<bool> IsRoleNameExist(string rolename)
        {
            try
            {
                var result = await _roleManager.RoleExistsAsync(rolename.ToLower());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in IsRoleNameExist");
                throw;
            }
        }
        public async Task<IdentityRole<int>> GetRoleByID(int Id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(Id.ToString());
                return role;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetRoleByID");
                throw;
            }
        }


        public async Task<List<IdentityRole<int>>> GetRoleListAsync()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetRoleListAsync");
                throw;
            }
        }

        //public async Task<IdentityUserRole<int>> GetManagerUsersRolesData(IdentityUser<int> user)
        //{
        //    try
        //    {
        //        var userRoles = new List<IdentityUserRole<int>>();
        //        //var response = new IdentityUserRole<int>();

        //        var rolesForUser = await _userManager.GetRolesAsync(user);
        //        var rolesInSystem = await _roleManager.Roles.ToListAsync();


        //        foreach (var role in rolesInSystem)
        //        {
        //            var userRole = new IdentityUserRole<int>();
        //            userRole.RoleId = role.Id;
        //            userRole.r = role.Name!;
        //            userRole.HasRole = rolesForUser.Contains(role.Name!);
        //            userRoles.Add(userRole);
        //        }

        //        response.UserId = user.Id;
        //        response.UserRoles = userRoles;

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogDebug(ex, "Error in GetManagerUsersRolesData");
        //        throw;
        //    }
        //}

        public async Task<ApiResponse> UpdateUserRoles(int UserId, IEnumerable<string> roles)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId.ToString());
                if (user == null)
                {
                    return new ApiResponse(404,"UserNotFound");
                }

                var rolesForUser = await _userManager.GetRolesAsync(user);
                if (rolesForUser.Count > 0)
                {
                    var IsDeleted = await _userManager.RemoveFromRolesAsync(user, rolesForUser);
                    if (!IsDeleted.Succeeded)
                        return new ApiResponse(500, "FailedDeleted");

                }

                //var newRoles = request.UserRoles.Where(x => x.HasRole == true).Select(x => x.Name);
                var IsAdded = await _userManager.AddToRolesAsync(user, roles);

                if (!IsAdded.Succeeded)
                    return new ApiResponse(500, "FailedAdded");

                await trans.CommitAsync();
                return new ApiResponse(200, "Success");
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in UpdateUserRoles");
                await trans.RollbackAsync();
                return new ApiResponse(500, "FaildAdded");
                throw;
            }
        }

        #endregion
    }
}
