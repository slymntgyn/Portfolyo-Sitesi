using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class TecrubelerimController : Controller {
		private readonly IServiceManager _manager;

		public TecrubelerimController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult DeneyimlerList() {
			List<Tecrübelerim> deneyimler = _manager.TecrubeService.GetTecrubeBilgileri().ToList();
			return View(deneyimler);
		}
		public IActionResult DeneyimlerEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult DeneyimlerEkle(Tecrübelerim deneyimler) {
			if (ModelState.IsValid) {
				_manager.TecrubeService.AddTecrubeBilgi(deneyimler);
				return RedirectToAction("DeneyimlerList");
			}
			return View();
		}
		public IActionResult DeneyimlerSil(int id) {
			_manager.TecrubeService.DeleteTecrubeBilgi(id);
			return RedirectToAction("DeneyimlerList");
		}
		public IActionResult DeneyimlerGuncelle(int id) {
			Tecrübelerim? deneyim = _manager.TecrubeService.GetTecrubeBilgileri().FirstOrDefault(x => x.Id == id);
			if (deneyim == null) {
				return NotFound();
			}
			return View(deneyim);
		}
		[HttpPost]
		public IActionResult DeneyimlerGuncelle(Tecrübelerim item) {
			if (ModelState.IsValid) {
				_manager.TecrubeService.UpdateTecrubeBilgi(item.Id, item);
				return RedirectToAction("DeneyimlerList");
			}
			return View();
		}
	}
}
