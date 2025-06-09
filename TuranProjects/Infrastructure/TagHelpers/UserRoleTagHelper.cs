using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TuranProjects_Portfolio.Infrastructure.TagHelpers {
	[HtmlTargetElement("td", Attributes = "user-role")]
	public class UserRoleTagHelper : TagHelper {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		[HtmlAttributeName("user-name")]
		public string UserName { get; set; }

		public UserRoleTagHelper(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager) {
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
			IdentityUser? user = await _userManager.FindByNameAsync(UserName);
			if (user == null) {
				output.Content.SetHtmlContent("<span class='text-danger'>User not found</span>");
				return;
			}

			List<string?> allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
			IList<string> userRoles = await _userManager.GetRolesAsync(user);

			TagBuilder div = new("div");
			div.AddCssClass("d-flex flex-wrap gap-1");

			foreach (string? role in allRoles) {
				bool hasRole = userRoles.Contains(role);

				TagBuilder span = new("span");
				span.AddCssClass($"badge {(hasRole ? "bg-success" : "bg-danger")} rounded-pill");
				span.InnerHtml.Append(role!);

				div.InnerHtml.AppendHtml(span);
			}

			output.Content.SetHtmlContent(div);
		}
	}
}
