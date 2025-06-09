using Microsoft.AspNetCore.Mvc;

namespace TuranProjects_Portfolio.ViewComponents.LayoutViewComponent {
	public class _LayoutSidebarComponentPartial : ViewComponent {
		public IViewComponentResult Invoke() {
			return View();
		}
	}
}
