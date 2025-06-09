using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;
namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class SosyalMedyalarController : Controller {
		private readonly IServiceManager _manager;

		public SosyalMedyalarController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<SosyalMedyalar> sosyalMedyalar = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri().ToList();
			return View(sosyalMedyalar);
		}
		public IActionResult SosyalMedyaEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult SosyalMedyaEkle(SosyalMedyalar sosyalMedya) {
			if (ModelState.IsValid) {
				_manager.SosyalMedyaService.AddSosyalMedyaBilgi(sosyalMedya);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult SosyalMedyaSil(int id) {
			SosyalMedyalar? sosyalMedya = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri().FirstOrDefault(x => x.Id == id);
			return RedirectToAction("Index");
		}
		public IActionResult SosyalMedyaGuncelle(int id) {
			SosyalMedyalar? sosyalMedya = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri().FirstOrDefault(x => x.Id == id);
			if (sosyalMedya == null) {
				return NotFound();
			}
			return View(sosyalMedya);
		}
		[HttpPost]
		public IActionResult SosyalMedyaGuncelle(SosyalMedyalar item) {
			if (ModelState.IsValid) {
				_manager.SosyalMedyaService.UpdateSosyalMedyaBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
