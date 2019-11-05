using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.db.Migrations
{
    public partial class tipKonkursa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipKonkursa",
                table: "Konkursi");

            migrationBuilder.AddColumn<int>(
                name: "TipKonkursaId",
                table: "Konkursi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipKonkursa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKonkursa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konkursi_TipKonkursaId",
                table: "Konkursi",
                column: "TipKonkursaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Konkursi_TipKonkursa_TipKonkursaId",
                table: "Konkursi",
                column: "TipKonkursaId",
                principalTable: "TipKonkursa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Konkursi_TipKonkursa_TipKonkursaId",
                table: "Konkursi");

            migrationBuilder.DropTable(
                name: "TipKonkursa");

            migrationBuilder.DropIndex(
                name: "IX_Konkursi_TipKonkursaId",
                table: "Konkursi");

            migrationBuilder.DropColumn(
                name: "TipKonkursaId",
                table: "Konkursi");

            migrationBuilder.AddColumn<string>(
                name: "TipKonkursa",
                table: "Konkursi",
                nullable: true);
        }
    }
}
