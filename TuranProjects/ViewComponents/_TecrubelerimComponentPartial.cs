using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _TecrubelerimComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _TecrubelerimComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			List<Tecrübelerim> tecrübelerim = _manager.TecrubeService.GetTecrubeBilgileri().ToList();
			return View(tecrübelerim);
		}
	}
}
