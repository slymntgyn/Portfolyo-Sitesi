using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _ProjelerimComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _ProjelerimComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			IEnumerable<Projeler> projelerim = _manager.ProjeService.GetProjeBilgileri();
			return View(projelerim);
		}
	}
}
