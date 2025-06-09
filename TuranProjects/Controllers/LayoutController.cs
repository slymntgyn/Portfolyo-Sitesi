using Microsoft.AspNetCore.Mvc;

namespace TuranProjects_Portfolio.Controllers {
	public class LayoutController : Controller {
		public IActionResult Index() {
			return View();
		}
	}
}
