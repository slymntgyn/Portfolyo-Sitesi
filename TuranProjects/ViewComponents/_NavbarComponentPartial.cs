using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _NavbarComponentPartial : ViewComponent {

		private readonly IServiceManager _manager;

		public _NavbarComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri()
				.FirstOrDefault();
			return View(hakkinda);
		}
	}
}
