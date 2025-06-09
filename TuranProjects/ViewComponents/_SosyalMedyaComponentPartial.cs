using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _SosyalMedyaComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _SosyalMedyaComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			IEnumerable<SosyalMedyalar> sosyalmedya = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri();
			return View(sosyalmedya);
		}
	}
}
