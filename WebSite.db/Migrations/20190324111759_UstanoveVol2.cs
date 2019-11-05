using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.db.Migrations
{
    public partial class UstanoveVol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KantonId",
                table: "Ustanove",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ustanove_KantonId",
                table: "Ustanove",
                column: "KantonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ustanove_Kantoni_KantonId",
                table: "Ustanove",
                column: "KantonId",
                principalTable: "Kantoni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ustanove_Kantoni_KantonId",
                table: "Ustanove");

            migrationBuilder.DropIndex(
                name: "IX_Ustanove_KantonId",
                table: "Ustanove");

            migrationBuilder.DropColumn(
                name: "KantonId",
                table: "Ustanove");
        }
    }
}
