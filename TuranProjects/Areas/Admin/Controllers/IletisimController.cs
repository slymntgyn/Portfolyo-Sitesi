using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class IletisimController : Controller {
		// GET: Iletisim
		private readonly IServiceManager _manager;

		public IletisimController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<Contact> iletisim = _manager.IletisimService.GetIletisimBilgileri().ToList();
			return View(iletisim);
		}
		public IActionResult IletisimEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult IletisimEkle(Contact iletisim) {
			if (ModelState.IsValid) {
				_manager.IletisimService.AddIletisimBilgi(iletisim);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult IletisimSil(int id) {
			_manager.IletisimService.DeleteIletisimBilgi(id);
			return RedirectToAction("Index");
		}
		public IActionResult IletisimGuncelle(int id) {
			Contact? iletisim = _manager.IletisimService.GetIletisimBilgileri().FirstOrDefault(x => x.Id == id);
			if (iletisim == null) {
				return NotFound();
			}
			return View(iletisim);
		}
		[HttpPost]
		public IActionResult IletisimGuncelle(Contact item) {
			if (ModelState.IsValid) {
				_manager.IletisimService.UpdateIletisimBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
