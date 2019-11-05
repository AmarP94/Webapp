using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.db.Migrations
{
    public partial class LinkoviKategorije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KategorijeLinkova",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivKategorije = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijeLinkova", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Linkovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivLinka = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    KategorijeLinkovaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linkovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Linkovi_KategorijeLinkova_KategorijeLinkovaId",
                        column: x => x.KategorijeLinkovaId,
                        principalTable: "KategorijeLinkova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linkovi_KategorijeLinkovaId",
                table: "Linkovi",
                column: "KategorijeLinkovaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linkovi");

            migrationBuilder.DropTable(
                name: "KategorijeLinkova");
        }
    }
}
