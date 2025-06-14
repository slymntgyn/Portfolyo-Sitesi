using ENTITIES.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace YourNamespace.Helpers
{
    public static class CvPdfYardimci
    {
        // Modern renk paleti
        public static class Renkler
        {
            public static readonly string Birincil = "#1E40AF";      // Modern mavi
            public static readonly string Ikincil = "#64748B";       // Gri
            public static readonly string Vurgu = "#0F172A";         // Koyu gri
            public static readonly string Acik = "#F8FAFC";          // Açık arka plan
            public static readonly string Basari = "#10B981";        // Yeşil
            public static readonly string Kenarlık = "#E2E8F0";      // Kenarlık rengi
        }

        // Tipografi ayarları
        public static class Tipografi
        {
            public static readonly int BaslikAna = 28;
            public static readonly int BaslikAlt = 14;
            public static readonly int BolumBaslik = 13;
            public static readonly int Metin = 10;
            public static readonly int Kucuk = 9;
            public static readonly int CokKucuk = 8;
        }

        // Boşluk ayarları
        public static class Bosluk
        {
            public static readonly int Kucuk = 8;
            public static readonly int Orta = 15;
            public static readonly int Buyuk = 25;
            public static readonly int CokBuyuk = 30;
        }

        public static void VarsayilanStilleriUygula(this PageDescriptor sayfa)
        {
            sayfa.Size(PageSizes.A4);
            sayfa.Margin(0);
            sayfa.DefaultTextStyle(x => x
                .FontSize(Tipografi.Metin)
                .FontFamily("Segoe UI", "Arial", "sans-serif")
                .FontColor(Renkler.Vurgu));
        }

        public static void ModernBaslikOlustur(this IContainer container,
            Ozellik? ozellik,
            Hakkinda? hakkinda,
            Contact? iletisim,
            IWebHostEnvironment env)
        {
            container.Height(160).Background(Renkler.Birincil).Padding(Bosluk.CokBuyuk).Row(satir =>
            {
                // Sol taraf - Metin içeriği
                satir.RelativeItem().Column(sutun =>
                {
                    // Ana başlık
                    sutun.Item().Text(ozellik?.Baslik ?? "İsim Soyisim")
                        .FontSize(Tipografi.BaslikAna)
                        .Bold()
                        .FontColor(Colors.White);

                    // Alt başlık
                    if (!string.IsNullOrEmpty(ozellik?.Aciklama))
                    {
                        sutun.Item().PaddingTop(5).Text(ozellik.Aciklama)
                            .FontSize(Tipografi.BaslikAlt)
                            .FontColor(Colors.White);
                    }

                    // İletişim bilgileri
                    sutun.Item().PaddingTop(Bosluk.Orta).IletisimBilgileriOlustur(hakkinda, iletisim);
                });

                // Sağ taraf - Profil resmi
                if (!string.IsNullOrEmpty(hakkinda?.ResimYolu))
                {
                    satir.ConstantItem(100).ProfilResmiOlustur(hakkinda.ResimYolu, env);
                }
            });
        }

        private static void IletisimBilgileriOlustur(this IContainer container, Hakkinda? hakkinda, Contact? iletisim)
        {
            container.Row(iletisimSatir =>
            {
                // Email
                if (!string.IsNullOrEmpty(hakkinda?.Mail))
                {
                    iletisimSatir.AutoItem().PaddingRight(20).IletisimOgesiOlustur("✉", hakkinda.Mail);
                }

                // Telefon
                if (!string.IsNullOrEmpty(iletisim?.Telefon))
                {
                    iletisimSatir.AutoItem().PaddingRight(20).IletisimOgesiOlustur("📱", iletisim.Telefon);
                }

                // Konum
                if (!string.IsNullOrEmpty(hakkinda?.Şehir))
                {
                    iletisimSatir.AutoItem().IletisimOgesiOlustur("📍", hakkinda.Şehir);
                }
            });
        }

        private static void IletisimOgesiOlustur(this IContainer container, string ikon, string metin)
        {
            container.Row(ogeSatir =>
            {
                ogeSatir.AutoItem().PaddingRight(5).Text(ikon)
                    .FontSize(11).FontColor(Colors.White);
                ogeSatir.AutoItem().Text(metin)
                    .FontSize(Tipografi.Metin).FontColor(Colors.White);
            });
        }

        private static void ProfilResmiOlustur(this IContainer container, string resimYolu, IWebHostEnvironment env)
        {
            string tamYol = Path.Combine(env.WebRootPath, resimYolu.TrimStart('/', '\\'));
            if (File.Exists(tamYol))
            {
                byte[] resimBytes = File.ReadAllBytes(tamYol);
                container.AlignCenter().AlignMiddle()
                    .Width(90).Height(90)
                    .Container()
                    .Border(3)
                    .Image(resimBytes);
            }
        }

        public static void BolumBasligiOlustur(this IContainer container, string baslik)
        {
            container.Row(baslikSatir =>
            {
                baslikSatir.AutoItem().PaddingRight(10)
                    .Width(3).Height(18).Background(Renkler.Birincil);
                baslikSatir.RelativeItem().Text(baslik)
                    .Bold().FontSize(Tipografi.BolumBaslik).FontColor(Renkler.Birincil);
            });
        }

        public static void HakkindaBolumuOlustur(this IContainer container, Hakkinda? hakkinda)
        {
            if (hakkinda == null) return;

            container.PaddingBottom(Bosluk.Buyuk).Container()
                .Background(Renkler.Acik)
                .Padding(20)
                .Column(sutun =>
                {
                    sutun.Item().BolumBasligiOlustur("HAKKIMDA");

                    if (!string.IsNullOrEmpty(hakkinda.AltAciklama))
                    {
                        sutun.Item().PaddingTop(12).Text(hakkinda.AltAciklama)
                            .FontSize(Tipografi.Metin).LineHeight(1.5f);
                    }

                    // Kişisel bilgi kartları
                    sutun.Item().PaddingTop(Bosluk.Orta).Row(bilgiSatir =>
                    {
                        if (!string.IsNullOrEmpty(hakkinda.DogumGunu))
                        {
                            bilgiSatir.RelativeItem().BilgiKartiOlustur("Doğum Tarihi", hakkinda.DogumGunu);
                        }

                        if (!string.IsNullOrEmpty(hakkinda.Öğrenim))
                        {
                            bilgiSatir.RelativeItem().BilgiKartiOlustur("Eğitim", hakkinda.Öğrenim);
                        }
                    });
                });
        }

        private static void BilgiKartiOlustur(this IContainer container, string baslik, string deger)
        {
            container.Padding(5).Column(sutun =>
            {
                sutun.Item().Text(baslik).FontSize(Tipografi.Kucuk).Bold().FontColor(Renkler.Ikincil);
                sutun.Item().Text(deger).FontSize(Tipografi.Metin);
            });
        }

        public static void TecrubeBolumuOlustur(this IContainer container, IEnumerable<Tecrübelerim> tecrubeler, string baslik = "PROFESYONEL TECRÜBE")
        {
            if (!tecrubeler.Any()) return;

            container.PaddingBottom(Bosluk.Buyuk).Column(sutun =>
            {
                sutun.Item().BolumBasligiOlustur(baslik);

                foreach (Tecrübelerim tecrube in tecrubeler)
                {
                    sutun.Item().PaddingTop(Bosluk.Orta).Container()
                        .BorderBottom(1)
                        .PaddingBottom(Bosluk.Orta)
                        .Column(tecrubeKolonu =>
                        {
                            tecrubeKolonu.Item().Row(satir =>
                            {
                                satir.RelativeItem().Text(tecrube.Unvan ?? "")
                                    .Bold().FontSize(Tipografi.Metin + 1);
                                satir.AutoItem().Text(tecrube.Date ?? "")
                                    .FontSize(Tipografi.Kucuk).FontColor(Renkler.Ikincil);
                            });

                            if (!string.IsNullOrEmpty(tecrube.Baslik))
                            {
                                tecrubeKolonu.Item().PaddingTop(3).Text(tecrube.Baslik)
                                    .FontSize(Tipografi.Metin).FontColor(Renkler.Birincil).Bold();
                            }

                            if (!string.IsNullOrEmpty(tecrube.Aciklama))
                            {
                                tecrubeKolonu.Item().PaddingTop(5).Text(tecrube.Aciklama)
                                    .FontSize(Tipografi.Kucuk).LineHeight(1.4f).FontColor(Renkler.Ikincil);
                            }
                        });
                }
            });
        }

        public static void EgitimBolumuOlustur(this IContainer container, IEnumerable<Tecrübelerim> egitimler)
        {
            container.TecrubeBolumuOlustur(egitimler, "EĞİTİM");
        }

        public static void ProjeBolumuOlustur(this IContainer container, IEnumerable<Projeler> projeler)
        {
            if (!projeler.Any()) return;

            container.PaddingBottom(Bosluk.Buyuk).Column(sutun =>
            {
                sutun.Item().BolumBasligiOlustur("PROJELER");

                foreach (Projeler proje in projeler)
                {
                    sutun.Item().PaddingTop(Bosluk.Orta).Container()
                        .BorderBottom(1)
                        .PaddingBottom(Bosluk.Orta)
                        .Column(projeKolonu =>
                        {
                            projeKolonu.Item().Row(satir =>
                            {
                                satir.RelativeItem().Text(proje.Baslik ?? "")
                                    .Bold().FontSize(Tipografi.Metin + 1);

                                if (!string.IsNullOrEmpty(proje.Tip))
                                {
                                    satir.AutoItem().Container()
                                        .Background(Renkler.Birincil)
                                        .PaddingVertical(2).PaddingHorizontal(8)
                                        .Text(proje.Tip)
                                        .FontSize(Tipografi.CokKucuk).FontColor(Colors.White);
                                }
                            });

                            if (!string.IsNullOrEmpty(proje.Aciklama))
                            {
                                projeKolonu.Item().PaddingTop(5).Text(proje.Aciklama)
                                    .FontSize(Tipografi.Kucuk).LineHeight(1.4f).FontColor(Renkler.Ikincil);
                            }

                            if (!string.IsNullOrEmpty(proje.ProjeUrl))
                            {
                                projeKolonu.Item().PaddingTop(3).Text(proje.ProjeUrl)
                                    .FontSize(Tipografi.CokKucuk).FontColor(Renkler.Birincil);
                            }
                        });
                }
            });
        }

        public static void YetenekBolumuOlustur(this IContainer container, IEnumerable<Yeteneklerim> yetenekler)
        {
            if (!yetenekler.Any()) return;

            container.PaddingBottom(Bosluk.Buyuk).Container()
                .Background(Renkler.Acik)
                .Padding(15)
                .Column(sutun =>
                {
                    sutun.Item().Text("YETENEKLERİM")
                        .Bold().FontSize(Tipografi.BolumBaslik).FontColor(Renkler.Birincil);

                    foreach (Yeteneklerim yetenek in yetenekler)
                    {
                        sutun.Item().PaddingTop(10).Column(yetenekKolonu =>
                        {
                            yetenekKolonu.Item().Row(satir =>
                            {
                                satir.RelativeItem().Text(yetenek.Yetenek ?? "")
                                    .FontSize(Tipografi.Kucuk).Bold();
                                satir.AutoItem().Text($"{yetenek.YetenekYuzde}%")
                                    .FontSize(Tipografi.CokKucuk).FontColor(Renkler.Ikincil);
                            });

                            // Yetenek barı
                            if (int.TryParse(yetenek.YetenekYuzde, out int yuzde))
                            {
                                yetenekKolonu.Item().PaddingTop(3).Container()
                                    .Height(5)
                                    .Background(Colors.Grey.Lighten2)
                                    .Row(barSatir =>
                                    {
                                        barSatir.RelativeItem(yuzde)
                                            .Background(Renkler.Birincil);
                                        barSatir.RelativeItem(100 - yuzde)
                                            .Background(Colors.Transparent);
                                    });
                            }
                        });
                    }
                });
        }

        public static void SosyalMedyaBolumuOlustur(this IContainer container, IEnumerable<SosyalMedyalar> sosyalMedyalar)
        {
            if (!sosyalMedyalar.Any()) return;

            container.PaddingBottom(Bosluk.Buyuk).Container()
                .Background(Renkler.Acik)
                .Padding(15)
                .Column(sutun =>
                {
                    sutun.Item().Text("SOSYAL MEDYA")
                        .Bold().FontSize(Tipografi.BolumBaslik).FontColor(Renkler.Birincil);

                    foreach (SosyalMedyalar sosyal in sosyalMedyalar)
                    {
                        sutun.Item().PaddingTop(8).Row(satir =>
                        {
                            satir.AutoItem().PaddingRight(8)
                                .Container()
                                .Width(18).Height(18)
                                .Background(Renkler.Birincil)
                                .AlignCenter().AlignMiddle()
                                .Text("🔗").FontSize(Tipografi.CokKucuk).FontColor(Colors.White);

                            satir.RelativeItem().Column(linkKolonu =>
                            {
                                linkKolonu.Item().Text(sosyal.Adi ?? "")
                                    .FontSize(Tipografi.Kucuk).Bold();
                                linkKolonu.Item().Text(sosyal.Url ?? "")
                                    .FontSize(Tipografi.CokKucuk).FontColor(Renkler.Birincil);
                            });
                        });
                    }
                });
        }

        public static void ReferansBolumuOlustur(this IContainer container, IEnumerable<Referanslar> referanslar)
        {
            if (!referanslar.Any()) return;

            container.Container()
                .Background(Renkler.Acik)
                .Padding(15)
                .Column(sutun =>
                {
                    sutun.Item().Text("REFERANSLAR")
                        .Bold().FontSize(Tipografi.BolumBaslik).FontColor(Renkler.Birincil);

                    foreach (Referanslar referans in referanslar)
                    {
                        sutun.Item().PaddingTop(10).Column(referansKolonu =>
                        {
                            referansKolonu.Item().Text(referans.Isim ?? "")
                                .FontSize(Tipografi.Kucuk).Bold();
                            referansKolonu.Item().Text(referans.Baslik ?? "")
                                .FontSize(Tipografi.CokKucuk).FontColor(Renkler.Birincil);
                            if (!string.IsNullOrEmpty(referans.Aciklama))
                            {
                                referansKolonu.Item().PaddingTop(2).Text(referans.Aciklama)
                                    .FontSize(Tipografi.CokKucuk).LineHeight(1.3f).FontColor(Renkler.Ikincil);
                            }
                        });
                    }
                });
        }

        public static void ModernAltBilgiOlustur(this IContainer container)
        {
            container.Background(Colors.Grey.Lighten4).Padding(15)
                .Row(satir =>
                {
                    satir.RelativeItem().Text($"Son Güncelleme: {DateTime.Today:dd MMMM yyyy}")
                        .FontSize(Tipografi.CokKucuk).FontColor(Renkler.Ikincil);
                });
        }
    }
}