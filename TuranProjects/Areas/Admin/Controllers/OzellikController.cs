using ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TuranProjects_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class OzellikController : Controller
    {
        private readonly IServiceManager _manager;

        public OzellikController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            IEnumerable<Ozellik> ozellikler = _manager.OzelllikService.GetOzellikBilgileri();
            return View(ozellikler);
        }
        public IActionResult OzellikEkle()
        {
            string imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            List<string?> resimListesi = Directory.GetFiles(imageFolder)
                .Select(Path.GetFileName)
                .ToList();

            ViewBag.ResimListesi = new SelectList(
                resimListesi.Select(x => new { Value = x, Text = x }),
                "Value",
                "Text");

            return View();
        }
        [HttpPost]
        public IActionResult OzellikEkle(Ozellik ozellik)
        {
            if (ModelState.IsValid)
            {
                _manager.OzelllikService.AddOzellikBilgi(ozellik);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult OzellikSil(int id)
        {
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault(x => x.Id == id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SetOzellikSil(int id)
        {
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault(x => x.Id == id);
            if (ozellik != null)
            {
                _manager.OzelllikService.DeleteOzellikBilgi(id);
            }
            else
            {
                ModelState.AddModelError("", "Silinecek özellik bilgisi bulunamadı.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult OzellikGuncelle(int id)
        {
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault(x => x.Id == id);
            if (ozellik == null)
            {
                return NotFound();
            }
            string imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            List<string?> resimListesi = Directory.GetFiles(imageFolder)
                .Select(Path.GetFileName)
                .ToList();

            ViewBag.ResimListesi = new SelectList(
                resimListesi.Select(x => new { Value = x, Text = x }),
                "Value",
                "Text"
            );
            return View(ozellik);
        }
        [HttpPost]
        public IActionResult OzellikGuncelle(Ozellik item)
        {
            if (ModelState.IsValid)
            {
                item.Resim = "images/" + item.Resim;
                _manager.OzelllikService.UpdateOzellikBilgi(item.Id, item);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
