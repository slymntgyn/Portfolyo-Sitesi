using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _OzellikComponentPartial : ViewComponent {

		private readonly IServiceManager _manager;

		public _OzellikComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			Ozellik? ozellikler = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault();
			return View(ozellikler);
		}
	}
}
