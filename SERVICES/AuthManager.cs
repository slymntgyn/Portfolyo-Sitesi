using AutoMapper;
using ENTITIES.Dtos;
using Microsoft.AspNetCore.Identity;
using SERVICES.Contract;

namespace SERVICES {
	public class AuthManager : IAuthService {
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IMapper _mapper;

		public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper) {
			_roleManager = roleManager;
			_userManager = userManager;
			this._mapper = mapper;
		}

		public IEnumerable<IdentityRole> Roles => _roleManager.Roles.ToList();

		public async Task<IdentityResult> CreateRoleAsync(UserDtoForCreation userDtoForCreation) {
			// Map the UserDto to IdentityUser
			IdentityUser user = _mapper.Map<IdentityUser>(userDtoForCreation);
			// Check if the user already exists
			IdentityResult result = await _userManager.CreateAsync(user, userDtoForCreation.Password);
			if (result.Succeeded) {
				// Add the user to the specified roles
				foreach (string role in userDtoForCreation.Roles) {
					if (!await _roleManager.RoleExistsAsync(role)) {
						await _roleManager.CreateAsync(new IdentityRole(role));
					}
					await _userManager.AddToRoleAsync(user, role);
				}
			}
			else {
				throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
			}
			return result;
		}

		public bool DeleteUser(string userId) {
			IdentityUser? user = _userManager.FindByIdAsync(userId).Result;
			if (user == null) {
				return false;
			}
			IdentityResult result = _userManager.DeleteAsync(user).Result;
			if (result.Succeeded) {
				return true;
			}
			else {
				throw new Exception("User deletion failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
			}
		}

		public IEnumerable<IdentityUser> GetAllUsers() {
			return _userManager.Users.ToList();
		}

		public async Task<IdentityUser> GetOneUser(string userName) {
			return await _userManager.FindByNameAsync(userName);
		}

		public async Task<UserDtoForUpdate> GetOneUserForUpdate(string userName) {
			IdentityUser user = await GetOneUser(userName);
			if (user == null) {
				throw new Exception("User not found");
			}
			UserDtoForUpdate userDto = _mapper.Map<UserDtoForUpdate>(user);

			userDto.Roles = new HashSet<string>(Roles.Select(x => x.Name).ToList());
			userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));

			return userDto;

		}

		public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto model) {
			Task<IdentityUser> user = GetOneUser(model.UserName);
			if (user == null) {
				throw new Exception("User not found");
			}
			IdentityUser identityUser = user.Result;
			await _userManager.RemovePasswordAsync(identityUser);
			IdentityResult result = await _userManager.AddPasswordAsync(identityUser, model.NewPassword);

			if (!result.Succeeded) {
				throw new Exception("Şİfre değiştirilirken hata oluştu: " + string.Join(", ", result.Errors.Select(e => e.Description)));
			}
			return result;
		}

		public async Task UpdateUser(UserDtoForUpdate userDto) {
			IdentityUser user = await GetOneUser(userDto.UserName);
			if (user == null) {
				throw new Exception("User not found");
			}
			user.Email = userDto.Email;
			user.PhoneNumber = userDto.PhoneNumber;
			IdentityResult result = await _userManager.UpdateAsync(user);
			if (!result.Succeeded) {
				throw new Exception("User update failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
			}
			if (userDto.Roles.Count > 0) {
				// Remove the user from all roles
				IList<string> currentRoles = await _userManager.GetRolesAsync(user);
				await _userManager.RemoveFromRolesAsync(user, currentRoles);
				foreach (string role in userDto.Roles) {
					if (!await _roleManager.RoleExistsAsync(role)) {
						await _roleManager.CreateAsync(new IdentityRole(role));
					}
					await _userManager.AddToRoleAsync(user, role);
				}
			}
		}

	}
}
