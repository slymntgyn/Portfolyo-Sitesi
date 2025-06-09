using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using REPOSITORIES;

namespace TuranProjects_Portfolio.Infrastructure.Extensions {
	public static class ApplicationExtension {
		public static void ConfigureAndCheckMigration(this IApplicationBuilder app) {
			MyPortfolioContext context = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<MyPortfolioContext>();
			if (context.Database.GetPendingMigrations().Any()) {
				context.Database.Migrate();
			}
		}
		public static void ConfigureLocalization(this WebApplication app) {
			app.UseRequestLocalization(options => {
				options.AddSupportedCultures("tr-TR")
				.AddSupportedUICultures("tr-TR")
				.SetDefaultCulture("tr-TR");
			});
		}
		public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app) {
			const string adminUser = "Admin";
			const string adminPassword = "Admin_1234";
			//User manager
			UserManager<IdentityUser> userManager = app.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();
			//Role Manager
			RoleManager<IdentityRole> roleManager = app.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();
			IdentityUser? identityUser = await userManager.FindByNameAsync(adminUser);
			if (identityUser is null) {
				IdentityUser user = new() {
					UserName = adminUser,
					Email = "slymntgyn@hotmail.com",
					PhoneNumber = "0532 123 45 67"
				};
				IdentityResult result = await userManager.CreateAsync(user, adminPassword);
				if (result.Succeeded) {
					IdentityResult roleResult = await userManager.AddToRolesAsync(user,
						 roleManager.Roles
							.Select(r => r.Name!)
							.ToList()
						);
					if (!roleResult.Succeeded) {
						//Hata mesajı
						throw new Exception("Admin kullanıcısı oluşturulamadı");
					}
				}
				else {
					//Hata mesajı
					throw new Exception("Admin kullanıcısı oluşturulamadı");
				}
			}
		}
	}
}