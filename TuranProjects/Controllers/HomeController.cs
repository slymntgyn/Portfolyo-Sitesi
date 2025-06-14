using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
<<<<<<< HEAD
using QuestPDF.Infrastructure;
using SERVICES.Contract;
using YourNamespace.Helpers;
=======
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SERVICES.Contract;
>>>>>>> fe8c2c023767a203f9dce268d46032fc3ebc278a

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
<<<<<<< HEAD
            // Verileri çek
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault();
            IEnumerable<Tecrübelerim> tecrübelerim = _manager.TecrubeService.GetTecrubeBilgileri().Where(x => x.Tip == "İş Hayatı");
            IEnumerable<Tecrübelerim> egitimler = _manager.TecrubeService.GetTecrubeBilgileri().Where(x => x.Tip == "Eğitim");
=======
            Ozellik? ozellik = _manager.OzelllikService.GetOzellikBilgileri().FirstOrDefault();
            IEnumerable<Tecrübelerim> tecrübelerim = _manager.TecrubeService.GetTecrubeBilgileri();
>>>>>>> fe8c2c023767a203f9dce268d46032fc3ebc278a
            IEnumerable<Yeteneklerim> yeteneklerim = _manager.YetenekService.GetYetenekBilgileri();
            IEnumerable<Projeler> projeler = _manager.ProjeService.GetProjeBilgileri();
            IEnumerable<Referanslar> referanslar = _manager.ReferansService.GetReferansBilgileri();
            Hakkinda? hakkinda = _manager.HakindaService.GetHakkindaBilgileri().FirstOrDefault();
            IEnumerable<SosyalMedyalar> sosyalmedya = _manager.SosyalMedyaService.GetSosyalMedyalarBilgileri();
            Contact? iletisim = _manager.IletisimService.GetIletisimBilgileri().FirstOrDefault();

            QuestPDF.Settings.License = LicenseType.Community;

<<<<<<< HEAD
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
=======
            // Modern renkler
            string primaryColor = "#2563EB"; // Modern mavi
            string secondaryColor = "#64748B"; // Soft gri
            string accentColor = "#0F172A"; // Koyu gri
            string lightBg = "#F8FAFC"; // Açık gri arka plan

            Document document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(0);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial").FontColor(accentColor));

                    // Modern header section
                    page.Header().Height(180).Background(primaryColor).Padding(30).Row(row =>
                    {
                        row.RelativeItem().Column(column =>
                        {
                            column.Item().Text(ozellik?.Baslik ?? "Ad Soyad")
                                .FontSize(32)
                                .Bold()
                                .FontColor(Colors.White);

                            column.Item().PaddingTop(8).Text(ozellik?.Aciklama ?? "")
                                .FontSize(16)
                                .FontColor(Colors.White);
                            // .Opacity(0.9f); // Opacity kaldırıldı, QuestPDF TextBlockDescriptor'da yok

                            // İletişim bilgileri header'da
                            if (hakkinda != null || iletisim != null)
                            {
                                column.Item().PaddingTop(15).Row(contactRow =>
                                {
                                    if (!string.IsNullOrEmpty(hakkinda?.Mail))
                                    {
                                        contactRow.AutoItem().PaddingRight(20).Row(itemRow =>
                                        {
                                            itemRow.AutoItem().PaddingRight(5).Text("✉")
                                                .FontSize(12).FontColor(Colors.White);
                                            itemRow.AutoItem().Text(hakkinda.Mail)
                                                .FontSize(11).FontColor(Colors.White);
                                        });
                                    }

                                    if (iletisim != null && !string.IsNullOrEmpty(iletisim.Telefon))
                                    {
                                        contactRow.AutoItem().PaddingRight(20).Row(itemRow =>
                                        {
                                            itemRow.AutoItem().PaddingRight(5).Text("📱")
                                                .FontSize(12).FontColor(Colors.White);
                                            itemRow.AutoItem().Text(iletisim.Telefon)
                                                .FontSize(11).FontColor(Colors.White);
                                        });
                                    }

                                    if (!string.IsNullOrEmpty(hakkinda?.Şehir))
                                    {
                                        contactRow.AutoItem().Row(itemRow =>
                                        {
                                            itemRow.AutoItem().PaddingRight(5).Text("📍")
                                                .FontSize(12).FontColor(Colors.White);
                                            itemRow.AutoItem().Text(hakkinda.Şehir)
                                                .FontSize(11).FontColor(Colors.White);
                                        });
                                    }
                                });
                            }
                        });

                        // Profil resmi - modern tasarım
                        if (!string.IsNullOrEmpty(hakkinda?.ResimYolu))
                        {
                            string imagePath = Path.Combine(_env.WebRootPath, hakkinda.ResimYolu.TrimStart('/', '\\'));
                            if (System.IO.File.Exists(imagePath))
                            {
                                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                                row.ConstantItem(120).AlignCenter().AlignMiddle().Container()
                                    .Width(100).Height(100)
                                    .Background(Colors.White)
                                    .Border(4) // Sadece kalınlık verildi, renk default
                                    .ShowOnce()
                                    .Image(imageBytes);
                            }
                        }
                    });

                    page.Content().Padding(30).Column(column =>
                    {
                        // Hakkımda bölümü - modern card tasarım
                        if (hakkinda != null)
                        {
                            column.Item().PaddingBottom(25).Container()
                                .Background(lightBg)
                                .Padding(20)
                                .Column(cardColumn =>
                                {
                                    cardColumn.Item().Row(titleRow =>
                                    {
                                        titleRow.AutoItem().PaddingRight(10)
                                            .Width(4).Height(20).Background(primaryColor);
                                        titleRow.RelativeItem().Text("HAKKIMDA")
                                            .Bold().FontSize(14).FontColor(primaryColor);
                                    });

                                    cardColumn.Item().PaddingTop(10).Text(hakkinda.AltAciklama ?? "")
                                        .FontSize(11).LineHeight(1.4f);

                                    // Kişisel bilgiler - grid layout
                                    cardColumn.Item().PaddingTop(15).Row(infoRow =>
                                    {
                                        if (!string.IsNullOrEmpty(hakkinda.DogumGunu))
                                        {
                                            infoRow.RelativeItem().Container().Padding(5).Column(infoCol =>
                                            {
                                                infoCol.Item().Text("Doğum Tarihi").FontSize(9).Bold().FontColor(secondaryColor);
                                                infoCol.Item().Text(hakkinda.DogumGunu).FontSize(10);
                                            });
                                        }

                                        if (!string.IsNullOrEmpty(hakkinda.Öğrenim))
                                        {
                                            infoRow.RelativeItem().Container().Padding(5).Column(infoCol =>
                                            {
                                                infoCol.Item().Text("Eğitim").FontSize(9).Bold().FontColor(secondaryColor);
                                                infoCol.Item().Text(hakkinda.Öğrenim).FontSize(10);
                                            });
                                        }
                                    });
                                });
                        }

                        // İki sütunlu layout
                        column.Item().Row(mainRow =>
                        {
                            // Sol sütun - Ana içerik
                            mainRow.RelativeItem(2).PaddingRight(15).Column(leftColumn =>
                            {
                                // Tecrübeler
                                if (tecrübelerim.Any())
                                {
                                    leftColumn.Item().PaddingBottom(25).Column(expColumn =>
                                    {
                                        expColumn.Item().Row(titleRow =>
                                        {
                                            titleRow.AutoItem().PaddingRight(10)
                                                .Width(4).Height(20).Background(primaryColor);
                                            titleRow.RelativeItem().Text("PROFESYONEL TECRÜBE")
                                                .Bold().FontSize(14).FontColor(primaryColor);
                                        });

                                        foreach (Tecrübelerim tecrube in tecrübelerim)
                                        {
                                            expColumn.Item().PaddingTop(15).Container()
                                                .BorderBottom(1) // Sadece kalınlık verildi
                                                .PaddingBottom(15)
                                                .Column(itemColumn =>
                                                {
                                                    itemColumn.Item().Row(itemRow =>
                                                    {
                                                        itemRow.RelativeItem().Text(tecrube.Unvan ?? "")
                                                            .Bold().FontSize(12);
                                                        itemRow.AutoItem().Text(tecrube.Date ?? "")
                                                            .FontSize(10).FontColor(secondaryColor);
                                                    });

                                                    itemColumn.Item().PaddingTop(2).Text(tecrube.Baslik ?? "")
                                                        .FontSize(11).FontColor(primaryColor).Bold();

                                                    if (!string.IsNullOrWhiteSpace(tecrube.Aciklama))
                                                    {
                                                        itemColumn.Item().PaddingTop(5).Text(tecrube.Aciklama)
                                                            .FontSize(10).LineHeight(1.3f).FontColor(secondaryColor);
                                                    }
                                                });
                                        }
                                    });
                                }

                                // Projeler
                                if (projeler.Any())
                                {
                                    leftColumn.Item().PaddingBottom(25).Column(projColumn =>
                                    {
                                        projColumn.Item().Row(titleRow =>
                                        {
                                            titleRow.AutoItem().PaddingRight(10)
                                                .Width(4).Height(20).Background(primaryColor);
                                            titleRow.RelativeItem().Text("PROJELER")
                                                .Bold().FontSize(14).FontColor(primaryColor);
                                        });

                                        foreach (Projeler proje in projeler)
                                        {
                                            projColumn.Item().PaddingTop(15).Container()
                                                .BorderBottom(1) // Sadece kalınlık verildi
                                                .PaddingBottom(15)
                                                .Column(itemColumn =>
                                                {
                                                    itemColumn.Item().Row(itemRow =>
                                                    {
                                                        itemRow.RelativeItem().Text(proje.Baslik ?? "")
                                                            .Bold().FontSize(12);
                                                        itemRow.AutoItem().Container()
                                                            .Background(primaryColor)
                                                            .PaddingVertical(3).PaddingHorizontal(8)
                                                            .Text(proje.Tip ?? "")
                                                            .FontSize(8).FontColor(Colors.White);
                                                    });

                                                    if (!string.IsNullOrWhiteSpace(proje.Aciklama))
                                                    {
                                                        itemColumn.Item().PaddingTop(5).Text(proje.Aciklama)
                                                            .FontSize(10).LineHeight(1.3f).FontColor(secondaryColor);
                                                    }

                                                    if (!string.IsNullOrWhiteSpace(proje.ProjeUrl))
                                                    {
                                                        itemColumn.Item().PaddingTop(5).Text(proje.ProjeUrl)
                                                            .FontSize(9).FontColor(primaryColor);
                                                    }
                                                });
                                        }
                                    });
                                }
                            });

                            // Sağ sütun - Yan bilgiler
                            mainRow.RelativeItem(1).Column(rightColumn =>
                            {
                                // Yetenekler
                                if (yeteneklerim.Any())
                                {
                                    rightColumn.Item().PaddingBottom(25).Container()
                                        .Background(lightBg)
                                        .Padding(15)
                                        .Column(skillColumn =>
                                        {
                                            skillColumn.Item().Text("YETENEKLERİM")
                                                .Bold().FontSize(12).FontColor(primaryColor);

                                            foreach (Yeteneklerim yetenek in yeteneklerim)
                                            {
                                                skillColumn.Item().PaddingTop(10).Column(itemColumn =>
                                                {
                                                    itemColumn.Item().Row(skillRow =>
                                                    {
                                                        skillRow.RelativeItem().Text(yetenek.Yetenek ?? "")
                                                            .FontSize(10).Bold();
                                                        skillRow.AutoItem().Text($"{yetenek.YetenekYuzde}%")
                                                            .FontSize(9).FontColor(secondaryColor);
                                                    });

                                                    // Skill bar
                                                    int yuzde = 0;
                                                    int.TryParse(yetenek.YetenekYuzde, out yuzde);
                                                    itemColumn.Item().PaddingTop(3).Container()
                                                        .Height(6)
                                                        .Background(Colors.Grey.Lighten2)
                                                        .Row(barRow =>
                                                        {
                                                            barRow.RelativeItem(yuzde)
                                                                .Background(primaryColor);
                                                            barRow.RelativeItem(100 - yuzde)
                                                                .Background(Colors.Transparent);
                                                        });
                                                });
                                            }
                                        });
                                }

                                // Sosyal Medya
                                if (sosyalmedya.Any())
                                {
                                    rightColumn.Item().PaddingBottom(25).Container()
                                        .Background(lightBg)
                                        .Padding(15)
                                        .Column(socialColumn =>
                                        {
                                            socialColumn.Item().Text("SOSYAL MEDYA")
                                                .Bold().FontSize(12).FontColor(primaryColor);

                                            foreach (SosyalMedyalar social in sosyalmedya)
                                            {
                                                socialColumn.Item().PaddingTop(8).Row(socialRow =>
                                                {
                                                    socialRow.AutoItem().PaddingRight(8)
                                                        .Container()
                                                        .Width(20).Height(20)
                                                        .Background(primaryColor)
                                                        .AlignCenter().AlignMiddle()
                                                        .Text("🔗").FontSize(10).FontColor(Colors.White);

                                                    socialRow.RelativeItem().Column(linkColumn =>
                                                    {
                                                        linkColumn.Item().Text(social.Adi ?? "")
                                                            .FontSize(10).Bold();
                                                        linkColumn.Item().Text(social.Url ?? "")
                                                            .FontSize(8).FontColor(primaryColor);
                                                    });
                                                });
                                            }
                                        });
                                }

                                // Referanslar
                                if (referanslar.Any())
                                {
                                    rightColumn.Item().Container()
                                        .Background(lightBg)
                                        .Padding(15)
                                        .Column(refColumn =>
                                        {
                                            refColumn.Item().Text("REFERANSLAR")
                                                .Bold().FontSize(12).FontColor(primaryColor);

                                            foreach (Referanslar referans in referanslar)
                                            {
                                                refColumn.Item().PaddingTop(10).Column(itemColumn =>
                                                {
                                                    itemColumn.Item().Text(referans.Isim ?? "")
                                                        .FontSize(10).Bold();
                                                    itemColumn.Item().Text(referans.Baslik ?? "")
                                                        .FontSize(9).FontColor(primaryColor);
                                                    itemColumn.Item().PaddingTop(2).Text(referans.Aciklama ?? "")
                                                        .FontSize(9).LineHeight(1.2f).FontColor(secondaryColor);
                                                });
                                            }
                                        });
                                }
>>>>>>> fe8c2c023767a203f9dce268d46032fc3ebc278a
                            });
                        });
                    });

                    // Modern footer
<<<<<<< HEAD
                    sayfa.Footer().ModernAltBilgiOlustur();
                });
            });

            return dokuman.GeneratePdf();
        }
=======
                    page.Footer().Background(Colors.Grey.Lighten4).Padding(15)
                        .Row(footerRow =>
                        {
                            footerRow.RelativeItem().Text($"Son Güncelleme: {DateTime.Today:dd MMMM yyyy}")
                                .FontSize(9).FontColor(secondaryColor);
                            //footerRow.AutoItem().Text("QuestPDF ile oluşturuldu")
                            //    .FontSize(9).FontColor(secondaryColor);
                        });
                });
            });

            return document.GeneratePdf();
        }

>>>>>>> fe8c2c023767a203f9dce268d46032fc3ebc278a
        public HomeController(IServiceManager manager, IWebHostEnvironment env)
        {
            _manager = manager;
            _env = env;
        }
    }
}
