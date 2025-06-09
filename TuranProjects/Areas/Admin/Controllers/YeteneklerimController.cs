using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class YeteneklerimController : Controller {
		private readonly IServiceManager _manager;

		public YeteneklerimController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<Yeteneklerim> yeteneklerim = _manager.YetenekService.GetYetenekBilgileri().ToList();
			return View(yeteneklerim);
		}
		public IActionResult YetenekEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult YetenekEkle(Yeteneklerim item) {
			if (item is null) {
				throw new ArgumentNullException(nameof(item));
			}

			if (ModelState.IsValid) {
				_manager.YetenekService.AddYetenekBilgi(item);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult YetenekSil(int id) {
			Yeteneklerim? yetenek = _manager.YetenekService.GetYetenekBilgileri().FirstOrDefault(x => x.Id == id);
			return RedirectToAction("Index");
		}
		public IActionResult YetenekGuncelle(int id) {
			Yeteneklerim? yetenek = _manager.YetenekService.GetYetenekBilgileri().FirstOrDefault(x => x.Id == id);
			if (yetenek == null) {
				return NotFound();
			}
			return View(yetenek);
		}
		[HttpPost]
		public IActionResult YetenekGuncelle(Yeteneklerim item) {
			if (ModelState.IsValid) {
				_manager.YetenekService.UpdateYetenekBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
