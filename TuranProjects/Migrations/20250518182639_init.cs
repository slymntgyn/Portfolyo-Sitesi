using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuranProjects_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon2 = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Email2 = table.Column<string>(type: "TEXT", nullable: true),
                    Adres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hakkindas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: false),
                    AltAciklama = table.Column<string>(type: "TEXT", nullable: false),
                    DogumGunu = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false),
                    Şehir = table.Column<string>(type: "TEXT", nullable: false),
                    Öğrenim = table.Column<string>(type: "TEXT", nullable: false),
                    Mail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkindas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isim = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Konu = table.Column<string>(type: "TEXT", nullable: false),
                    Mesaj = table.Column<string>(type: "TEXT", nullable: false),
                    GonderilmeTarihi = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ozelliks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama2 = table.Column<string>(type: "TEXT", nullable: false),
                    Resim = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ozelliks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: false),
                    Tip = table.Column<string>(type: "TEXT", nullable: false),
                    AltBaslik = table.Column<string>(type: "TEXT", nullable: false),
                    ResimYolu = table.Column<string>(type: "TEXT", nullable: true),
                    ProjeUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projelers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referanslars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isim = table.Column<string>(type: "TEXT", nullable: false),
                    Baslik = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalMedyalars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adi = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Durum = table.Column<bool>(type: "INTEGER", nullable: false),
                    SiraNo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalMedyalars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecrübelerims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tip = table.Column<string>(type: "TEXT", nullable: false),
                    Baslik = table.Column<string>(type: "TEXT", nullable: false),
                    Unvan = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Aciklama = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecrübelerims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yeteneklerims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Yetenek = table.Column<string>(type: "TEXT", nullable: false),
                    YetenekAciklama = table.Column<string>(type: "TEXT", nullable: false),
                    YetenekYuzde = table.Column<string>(type: "TEXT", nullable: false),
                    YetenekIcon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yeteneklerims", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Hakkindas");

            migrationBuilder.DropTable(
                name: "Mesajlars");

            migrationBuilder.DropTable(
                name: "Ozelliks");

            migrationBuilder.DropTable(
                name: "Projelers");

            migrationBuilder.DropTable(
                name: "Referanslars");

            migrationBuilder.DropTable(
                name: "SosyalMedyalars");

            migrationBuilder.DropTable(
                name: "Tecrübelerims");

            migrationBuilder.DropTable(
                name: "Yeteneklerims");
        }
    }
}
