using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace REPOSITORIES.Config {
	public class IdentityRoleConfig : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<IdentityRole> {
		public void Configure(EntityTypeBuilder<IdentityRole> builder) {
			builder.HasData(
				new IdentityRole {
					Id = "1",
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole {
					Id = "2",
					Name = "User",
					NormalizedName = "USER"
				},
				new IdentityRole {
					Id = "3",
					Name = "Guest",
					NormalizedName = "GUEST"
				},
				new IdentityRole {
					Id = "4",
					Name = "SuperAdmin",
					NormalizedName = "SUPERADMIN"
				},
				new IdentityRole {
					Id = "5",
					Name = "Editör",
					NormalizedName = "EDITOR"
				}
			);
		}
	}
}
