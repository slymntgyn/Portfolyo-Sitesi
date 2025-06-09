using QuestPDF.Infrastructure;
using TuranProjects_Portfolio.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Database tanýmlamalarý
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
//Repository tanýmlamalarý
builder.Services.ConfigureRepositoryRegistration();
//Servis tanýmlamalarý
builder.Services.ConfigureServiceRegistration();
//Lower case routing tanýmlamalarý
builder.Services.ConfigureRouting();
//Identity tanýmlamalarý
builder.Services.ConfigureIdentity();
//Cookie tanýmlamalarý
builder.Services.ConfigurationCookie();

builder.Services.AddAutoMapper(typeof(Program));

WebApplication app = builder.Build();
QuestPDF.Settings.License = LicenseType.Community;
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.ConfigureAndCheckMigration();
app.ConfigureDefaultAdminUser();
app.MapStaticAssets();
app.MapAreaControllerRoute(
	name: "Admin",
	areaName: "Admin",
	pattern: "Admin/{controller=Hakkinda}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();


app.Run();
