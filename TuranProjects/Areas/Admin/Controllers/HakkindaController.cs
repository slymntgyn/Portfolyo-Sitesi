using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Contract;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers {
	[Area("Admin")]
	[Authorize(Roles = "Admin,SuperAdmin")]
	public class HakkindaController : Controller {
		private readonly IServiceManager _manager;

		public HakkindaController(IServiceManager manager) {
			_manager = manager;
		}

		public IActionResult Index() {
			IEnumerable<Hakkinda> hakkinda = _manager.HakindaService.GetHakkindaBilgileri();
			return View(hakkinda);
		}
		public IActionResult HakkindaEkle() {
			return View();
		}
		[HttpPost]
		public IActionResult HakkindaEkle(Hakkinda hakkinda) {
			if (ModelState.IsValid) {
				_manager.HakindaService.AddHakkindaBilgi(hakkinda);
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult HakkindaSil(int id) {
			Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault(x => x.Id == id);
			if (hakkinda != null) {
				_manager.HakindaService.DeleteHakkindaBilgi(id);
			}
			else {
				ModelState.AddModelError("", "Silinecek Hakkında bilgisi bulunamadı.");
			}
			return RedirectToAction("Index");
		}
		public IActionResult HakkindaGuncelle(int id) {
			Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault(x => x.Id == id);
			if (hakkinda == null) {
				return NotFound();
			}
			return View(hakkinda);
		}
		[HttpPost]
		public IActionResult HakkindaGuncelle(Hakkinda item) {
			if (ModelState.IsValid) {
				Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault(x => x.Id == item.Id);
				if (hakkinda != null) {
					hakkinda.Baslik = item.Baslik;
					hakkinda.AltAciklama = item.AltAciklama;
					hakkinda.DogumGunu = item.DogumGunu;
					hakkinda.Telefon = item.Telefon;
					hakkinda.Şehir = item.Şehir;
					hakkinda.Öğrenim = item.Öğrenim;
					hakkinda.Mail = item.Mail;
					hakkinda.ResimYolu = item.ResimYolu;

					_manager.HakindaService.UpdateHakkindaBilgi(item.Id, hakkinda);
				}
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
