using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class MesajController : Controller {
		// GET: Iletisim
		private readonly IServiceManager _manager;

		public MesajController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			List<Message> mesajlar = _manager.MesajService.GetAllMessages().ToList();
			return View(mesajlar);
		}
		public IActionResult MesajEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult MesajEkle(Message mesaj) {
			if (ModelState.IsValid) {
				_manager.MesajService.AddMesajBilgi(mesaj);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult MesajSil(int id) {
			Message? mesaj = _manager.MesajService.GetAllMessages().FirstOrDefault(x => x.Id == id);
			if (mesaj != null) {
				_manager.MesajService.DeleteMesajBilgi(id);
			}
			else {
				return NotFound();
			}
			return RedirectToAction("Index");
		}
		public IActionResult MesajGuncelle(int id) {
			Message? mesaj = _manager.MesajService.GetAllMessages().FirstOrDefault(x => x.Id == id);
			if (mesaj == null) {
				return NotFound();
			}
			return View(mesaj);
		}
		[HttpPost]
		public IActionResult MesajGuncelle(Message item) {
			if (ModelState.IsValid) {
				_manager.MesajService.UpdateMesajBilgi(item.Id, item);
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
