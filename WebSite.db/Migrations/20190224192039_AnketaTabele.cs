using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.db.Migrations
{
    public partial class AnketaTabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ankete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivAnkete = table.Column<string>(nullable: true),
                    AktivnaAnketa = table.Column<bool>(nullable: false),
                    DatumAnkete = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ankete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdgovoriAnkete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Odgovor = table.Column<string>(nullable: true),
                    AnketaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdgovoriAnkete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdgovoriAnkete_Ankete_AnketaId",
                        column: x => x.AnketaId,
                        principalTable: "Ankete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdgovoriAnkete_AnketaId",
                table: "OdgovoriAnkete",
                column: "AnketaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdgovoriAnkete");

            migrationBuilder.DropTable(
                name: "Ankete");
        }
    }
}
