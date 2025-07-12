using EliteCare.Service.BaseResponse;
using Microsoft.AspNetCore.Identity;

namespace EliteCare.Data.ServiceAbstract
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
