using Microsoft.AspNetCore.Mvc;

namespace TuranProjects_Portfolio.ViewComponents.LayoutViewComponent {
	public class _LayoutHeadComponentPartial : ViewComponent {
		public IViewComponentResult Invoke() {
			return View();
		}
	}
}
