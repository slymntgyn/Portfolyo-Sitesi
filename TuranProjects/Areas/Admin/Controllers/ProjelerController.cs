using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class ProjelerController : Controller {

		private readonly IServiceManager _manager;

		public ProjelerController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<Projeler> projeler = _manager.ProjeService.GetProjeBilgileri().ToList();
			return View(projeler);
		}
		public IActionResult ProjeEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult ProjeEkle(Projeler proje) {
			if (ModelState.IsValid) {
				_manager.ProjeService.AddProjeBilgi(proje);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult ProjeSil(int id) {
			_manager.ProjeService.DeleteProjeBilgi(id);
			return RedirectToAction("Index");
		}
		public IActionResult ProjeGuncelle(int id) {
			Projeler? proje = _manager.ProjeService.GetProjeById(id);
			if (proje == null) {
				return NotFound();
			}
			return View(proje);
		}
		[HttpPost]
		public IActionResult ProjeGuncelle(Projeler item) {
			if (ModelState.IsValid) {
				_manager.ProjeService.UpdateProjeBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
