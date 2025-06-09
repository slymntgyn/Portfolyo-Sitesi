using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using REPOSITORIES;
using REPOSITORIES.Contracts;
using SERVICES;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Infrastructure.Extensions {
	public static class ServiceExtension {
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) {
			services.AddDbContext<MyPortfolioContext>(options => {
				options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly("TuranProjects_Portfolio"));
				options.EnableSensitiveDataLogging();
			});
		}


		public static void ConfigureRepositoryRegistration(this IServiceCollection services) {
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IHakkindaRepository, HakkindaRepository>();
			services.AddScoped<IIletisimRepository, IletisimRepository>();
			services.AddScoped<IMesajRepository, MesajRepository>();
			services.AddScoped<IOzellikRepository, OzellikRepository>();
			services.AddScoped<IProjelerRepository, ProjelerRepository>();
			services.AddScoped<IReferanslarRepository, ReferanslarRepository>();
			services.AddScoped<ISosyalMedyalarRepository, SosyalMedyalarRepository>();
			services.AddScoped<ITecrübelerimRepository, TecrübelerimRepository>();
			services.AddScoped<IYeteneklerimRepository, YeteneklerimRepository>();
		}
		public static void ConfigureIdentity(this IServiceCollection services) {
			services.AddIdentity<IdentityUser, IdentityRole>(options => {
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequiredLength = 8;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;
				options.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<MyPortfolioContext>().AddDefaultTokenProviders();
		}
		public static void ConfigurationCookie(this IServiceCollection services) {
			services.ConfigureApplicationCookie(options => {
				options.LoginPath = new PathString("/Account/Login");
				options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
				options.AccessDeniedPath = new PathString("/Account/AccessDenied");
				options.SlidingExpiration = true;
				options.ExpireTimeSpan = TimeSpan.FromDays(10);
				options.Cookie.HttpOnly = true;
			});
		}

		public static void ConfigureRouting(this IServiceCollection services) {
			services.AddRouting(options => {
				options.LowercaseUrls = true;
				options.LowercaseQueryStrings = true;
				options.AppendTrailingSlash = true;

			});
		}

		public static void ConfigureServiceRegistration(this IServiceCollection services) {
			services.AddScoped<IHakkindaService, HakkindaManager>();
			services.AddScoped<IIletisimService, IletisimManager>();
			services.AddScoped<IMesajService, MesajManager>();
			services.AddScoped<IOzellikService, OzellikManager>();
			services.AddScoped<IProjelerService, ProjelerManager>();
			services.AddScoped<IReferanslarService, ReferanslarManager>(); // Fix: Ensure ReferanslarManager implements IReferanslarService  
			services.AddScoped<ISosyalMedyalarService, SosyalMedyalarManager>();
			services.AddScoped<ITecrübelerimService, TecrübelerimManager>();
			services.AddScoped<IYeteneklerimService, YeteneklerimManager>();
			services.AddScoped<IAuthService, AuthManager>();
			services.AddScoped<IServiceManager, ServiceManager>();

		}
	}
}
