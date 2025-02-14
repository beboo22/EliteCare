using EliteCare.Service.BaseResponse;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteCare.Service.Abstract
{
    public interface IAuthorizationService
    {
        public Task<bool> AddRoleAsync(string roleName);
        public Task<bool> EditRoleById(int Id, string roleName);
        public Task<bool> DeleteRoleById(IdentityRole<int> role);
        public Task<bool> IsRoleNameExist(string rolename);
        public Task<IdentityRole<int>> GetRoleByID(int Id);
        public Task<List<IdentityRole<int>>> GetRoleListAsync();
        //public Task<IdentityUserRole<int>> GetManagerUsersRolesData(IdentityUser<int> user);
        public Task<ApiResponse> UpdateUserRoles(int UserId, IEnumerable<string> roles);
    }
}
