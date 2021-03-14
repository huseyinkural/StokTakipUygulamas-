using Microsoft.EntityFrameworkCore.Migrations;

namespace StokTakipUygulaması.Migrations
{
    public partial class KullaniciDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(nullable: true),
                    Soyisim = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(nullable: true),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
