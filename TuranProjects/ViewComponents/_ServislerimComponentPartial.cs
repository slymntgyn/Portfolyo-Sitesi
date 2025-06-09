using Microsoft.AspNetCore.Mvc;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _ServislerimComponentPartial : ViewComponent {
		public IViewComponentResult Invoke() {
			return View();
		}
	}
}
