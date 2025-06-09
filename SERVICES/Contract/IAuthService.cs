using ENTITIES.Dtos;
using Microsoft.AspNetCore.Identity;

namespace SERVICES.Contract {
	public interface IAuthService {
		IEnumerable<IdentityRole> Roles { get; }
		IEnumerable<IdentityUser> GetAllUsers();
		Task<IdentityResult> CreateRoleAsync(UserDtoForCreation userDto);
		Task<IdentityUser> GetOneUser(string username);
		Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);
		Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto model);
		Task UpdateUser(UserDtoForUpdate userDto);
		bool DeleteUser(string userId);
	}
}
