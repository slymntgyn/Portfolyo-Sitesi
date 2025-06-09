using Microsoft.AspNetCore.Mvc;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _HeadComponentPartial : ViewComponent {
		public IViewComponentResult Invoke() {
			return View();
		}
	}
}
