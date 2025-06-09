using ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace REPOSITORIES {
	public class MyPortfolioContext : IdentityDbContext<IdentityUser> {

		public MyPortfolioContext(DbContextOptions<MyPortfolioContext> options) : base(options) { }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Hakkinda> Hakkindas { get; set; }
		public DbSet<Message> Mesajlars { get; set; }
		public DbSet<Ozellik> Ozelliks { get; set; }
		public DbSet<Projeler> Projelers { get; set; }
		public DbSet<Referanslar> Referanslars { get; set; }
		public DbSet<SosyalMedyalar> SosyalMedyalars { get; set; }
		public DbSet<Tecrübelerim> Tecrübelerims { get; set; }
		public DbSet<Yeteneklerim> Yeteneklerims { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			// Kimlik şemalarını oluştur
			base.OnModelCreating(modelBuilder);

			// Tüm konfigürasyonları otomatik uygula (Fluent API için)
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			// Kimlik tablolarının adlarını özelleştirmek istersen:
			modelBuilder.Entity<IdentityUser>(entity => {
				entity.ToTable("Users");
			});

			modelBuilder.Entity<IdentityRole>(entity => {
				entity.ToTable("Roles");
			});

			modelBuilder.Entity<IdentityUserRole<string>>(entity => {
				entity.ToTable("UserRoles");
			});
		}
	}
}
