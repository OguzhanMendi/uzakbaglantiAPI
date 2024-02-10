using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace uzakbaglantiAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baglanti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sirketAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baglantiAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baglantiId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    baglantiSifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkiliAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkiliTel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baglanti", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baglanti");

            migrationBuilder.DropTable(
                name: "kullanici");
        }
    }
}
