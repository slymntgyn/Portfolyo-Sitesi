using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.ViewComponents {
	public class _IletisimComponentPartial : ViewComponent {
		private readonly IServiceManager _manager;

		public _IletisimComponentPartial(IServiceManager manager) {
			_manager = manager;
		}

		public IViewComponentResult Invoke() {
			IEnumerable<Contact> iletisim = _manager.IletisimService.GetIletisimBilgileri();
			return View(iletisim);
		}
	}
}
