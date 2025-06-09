using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class ReferanslarController : Controller {
		private readonly IServiceManager _manager;

		public ReferanslarController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<Referanslar> referanslar = _manager.ReferansService.GetReferansBilgileri().ToList();
			return View(referanslar);
		}
		public IActionResult ReferansEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult ReferansEkle(Referanslar referans) {
			if (ModelState.IsValid) {
				_manager.ReferansService.AddReferansBilgi(referans);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult ReferansSil(int id) {
			_manager.ReferansService.DeleteReferansBilgi(id);
			return RedirectToAction("Index");
		}
		public IActionResult ReferansGuncelle(int id) {
			Referanslar? referans = _manager.ReferansService.GetReferansBilgileri().FirstOrDefault(x => x.Id == id);
			if (referans == null) {
				return NotFound();
			}
			return View(referans);
		}
		[HttpPost]
		public IActionResult ReferansGuncelle(Referanslar item) {
			if (ModelState.IsValid) {
				_manager.ReferansService.UpdateReferansBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
