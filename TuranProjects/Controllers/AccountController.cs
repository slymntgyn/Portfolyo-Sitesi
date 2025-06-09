using ENTITIES.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TuranProjects_Portfolio.Models;
namespace TuranProjects_Portfolio.Controllers {
	public class AccountController : Controller {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/") {
			return View(new LoginModel() {
				ReturnUrl = ReturnUrl,
			});
		}

		public IActionResult Register() {
			// Register logic here
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login([FromForm] LoginModel loginModel) {
			if (ModelState.IsValid) {
				IdentityUser? user = await _userManager.FindByNameAsync(loginModel.UserName);
				if (user != null) {
					bool result = await _userManager.CheckPasswordAsync(user, loginModel.Password);
					if (result) {
						await _signInManager.SignOutAsync();
						if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded) {
							if (Url.IsLocalUrl(loginModel.ReturnUrl)) {
								return Redirect(loginModel.ReturnUrl);
							}
							else {
								return RedirectToAction("Index", "Home");
							}
						}
						else {
							ModelState.AddModelError(string.Empty, "Giriş yapılamadı.");
						}
					}
					else {
						ModelState.AddModelError(string.Empty, "Geçersiz şifre.");
					}
				}
				else {
					ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı");
				}
			}
			else {
				ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doldurun.");
			}
			return View(loginModel);
		}
		public IActionResult Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/") {
			_signInManager.SignOutAsync();
			return Redirect(ReturnUrl);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([FromForm] RegisterDto registerDto) {
			if (ModelState.IsValid) {
				IdentityUser user = new() {
					UserName = registerDto.Username,
					Email = registerDto.Email,
				};
				IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);
				if (result.Succeeded) {
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				else {
					foreach (IdentityError error in result.Errors) {
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			return View(registerDto);
		}
		public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string returnUrl) {
			return View();
		}
	}
}
