using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SERVICES.Contract;
using YourNamespace.Helpers;

namespace TuranProjects_Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _manager;

        private readonly IWebHostEnvironment _env;

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("DownloadCv")]
        public IActionResult DownloadCv()
        {
            byte[] pdfBytes = GenerateCvPdf(); // yukarıdaki metodu çağır

            return File(pdfBytes, "application/pdf", "CV.pdf");
        }

        public byte[] GenerateCvPdf()
        {
            // Verileri çek
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault();
            IEnumerable<Tecrübelerim> tecrübelerim = _manager.TecrubeService.GetTecrubeBilgileri().Where(x => x.Tip == "İş Hayatı");
            IEnumerable<Tecrübelerim> egitimler = _manager.TecrubeService.GetTecrubeBilgileri().Where(x => x.Tip == "Eğitim");
            IEnumerable<Yeteneklerim> yeteneklerim = _manager.YetenekService.GetYetenekBilgileri();
            IEnumerable<Projeler> projeler = _manager.ProjeService.GetProjeBilgileri();
            IEnumerable<Referanslar> referanslar = _manager.ReferansService.GetReferansBilgileri();
            Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault();
            IEnumerable<SosyalMedyalar> sosyalmedya = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri();
            Contact? iletisim = _manager.IletisimService.GetIletisimBilgileri().FirstOrDefault();

            QuestPDF.Settings.License = LicenseType.Community;

            Document dokuman = Document.Create(container =>
            {
                container.Page(sayfa =>
                {
                    // Varsayılan stil ayarları
                    sayfa.VarsayilanStilleriUygula();

                    // Modern header
                    sayfa.Header().ModernBaslikOlustur(ozellik, hakkinda, iletisim, _env);

                    // Ana içerik
                    sayfa.Content().Padding(CvPdfYardimci.Bosluk.CokBuyuk).Column(anaSutun =>
                    {
                        // Hakkımda bölümü
                        anaSutun.Item().HakkindaBolumuOlustur(hakkinda);

                        // İki sütunlu düzen
                        anaSutun.Item().Row(anaSatir =>
                        {
                            // Sol sütun - Ana içerik (Tecrübe, Eğitim ve Projeler)
                            anaSatir.RelativeItem(2).PaddingRight(20).Column(solSutun =>
                            {
                                // İş Hayatı Tecrübeleri
                                solSutun.Item().TecrubeBolumuOlustur(tecrübelerim, "PROFESYONEL TECRÜBE");

                                // Eğitim Geçmişi
                                solSutun.Item().EgitimBolumuOlustur(egitimler);

                                // Projeler
                                solSutun.Item().ProjeBolumuOlustur(projeler);
                            });

                            // Sağ sütun - Yan bilgiler
                            anaSatir.RelativeItem(1).Column(sagSutun =>
                            {
                                // Yetenekler
                                sagSutun.Item().YetenekBolumuOlustur(yeteneklerim);

                                // Sosyal Medya
                                sagSutun.Item().SosyalMedyaBolumuOlustur(sosyalmedya);

                                // Referanslar
                                sagSutun.Item().ReferansBolumuOlustur(referanslar);
                            });
                        });
                    });

                    // Modern footer
                    sayfa.Footer().ModernAltBilgiOlustur();
                });
            });

            return dokuman.GeneratePdf();
        }
        public HomeController(IServiceManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
        }
    }
}
