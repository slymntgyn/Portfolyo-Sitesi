using ENTITIES.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace StoreApp.Areas.Admin.Controllers {
	// GET: UserController
	[Area("Admin")]
	public class UserController : Controller {
		private readonly IServiceManager _serviceManager;

		public UserController(IServiceManager serviceManager) {
			_serviceManager = serviceManager;
		}


		public IActionResult Index() {
			// Get all users from the service
			IEnumerable<IdentityUser> users = _serviceManager.AuthService.GetAllUsers();
			return View(users);
		}
		// GET: UserController/Create
		public IActionResult Create() {
			UserDtoForCreation roles = new() {
				Roles = new HashSet<string>(
						_serviceManager
						.AuthService
						.Roles
						.Select(r => r.Name)
						.ToList()
						)
			};
			return View(roles);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto) {
			Task<Microsoft.AspNetCore.Identity.IdentityResult> result = _serviceManager.AuthService.CreateRoleAsync(userDto);
			if (result.Result.Succeeded) {
				TempData["Success"] = "Kullanıcı başarıyla oluşturuldu.";
				return RedirectToAction("Index");
			}
			else {
				foreach (Microsoft.AspNetCore.Identity.IdentityError error in result.Result.Errors) {
					ModelState.AddModelError("", error.Description);
				}
				TempData["Error"] = "Kullanıcı oluşturulamadı.";
				return View(userDto);
			}

		}
		public IActionResult Delete(string id) {
			if (string.IsNullOrEmpty(id)) {
				TempData["Error"] = "Kullanıcı bulunamadı.";
				return RedirectToAction("Index");
			}
			bool result = _serviceManager.AuthService.DeleteUser(id);
			if (result) {
				TempData["Success"] = "Kullanıcı başarıyla silindi.";
			}
			else {
				TempData["Error"] = "Kullanıcı silinemedi.";
			}
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update([FromRoute(Name = "id")] string id) {
			UserDtoForUpdate user = await _serviceManager.AuthService.GetOneUserForUpdate(id);
			return View(user);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDto) {
			if (!ModelState.IsValid) {
				TempData["Error"] = "Kullanıcı güncellenemedi.";
				return View(userDto);
			}
			await _serviceManager.AuthService.UpdateUser(userDto);
			return RedirectToAction("Index");

		}
		public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id) {
			return View(new ResetPasswordDto() {
				UserName = id
			});
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto resetPasswordDto) {
			if (!ModelState.IsValid) {
				TempData["Error"] = "Şifre sıfırlanamadı.";
				return View(resetPasswordDto);
			}
			Microsoft.AspNetCore.Identity.IdentityResult result = await _serviceManager.AuthService.ResetPasswordAsync(resetPasswordDto);
			if (result.Succeeded) {
				TempData["Success"] = "Şifre başarıyla sıfırlandı.";
				return RedirectToAction("Index");
			}
			else {
				foreach (Microsoft.AspNetCore.Identity.IdentityError error in result.Errors) {
					ModelState.AddModelError("", error.Description);
				}
				TempData["Error"] = "Şifre sıfırlanamadı.";
				return View(resetPasswordDto);
			}
		}

	}
}