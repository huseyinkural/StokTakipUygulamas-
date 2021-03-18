using Microsoft.EntityFrameworkCore.Migrations;

namespace StokTakipUygulaması.Migrations
{
    public partial class KategoriVeAltKategoriOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kategoriler_AltKategoriler_AltKategoriId",
                table: "Kategoriler");

            migrationBuilder.DropIndex(
                name: "IX_Kategoriler_AltKategoriId",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "AltKategoriId",
                table: "Kategoriler");

            migrationBuilder.AlterColumn<string>(
                name: "Isim",
                table: "Kategoriler",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "AltKategoriler",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AltKategoriler_KategoriId",
                table: "AltKategoriler",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_AltKategoriler_Kategoriler_KategoriId",
                table: "AltKategoriler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AltKategoriler_Kategoriler_KategoriId",
                table: "AltKategoriler");

            migrationBuilder.DropIndex(
                name: "IX_AltKategoriler_KategoriId",
                table: "AltKategoriler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "AltKategoriler");

            migrationBuilder.AlterColumn<string>(
                name: "Isim",
                table: "Kategoriler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AltKategoriId",
                table: "Kategoriler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriler_AltKategoriId",
                table: "Kategoriler",
                column: "AltKategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kategoriler_AltKategoriler_AltKategoriId",
                table: "Kategoriler",
                column: "AltKategoriId",
                principalTable: "AltKategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
