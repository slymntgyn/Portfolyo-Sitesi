using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _YeteneklerimComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _YeteneklerimComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			IEnumerable<Yeteneklerim> yeteneklerim = _manager.YetenekService.GetYetenekBilgileri();
			return View(yeteneklerim);
		}
	}
}
