using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _HakkimdaComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _HakkimdaComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault();
			return View(hakkinda);
		}
	}
}
