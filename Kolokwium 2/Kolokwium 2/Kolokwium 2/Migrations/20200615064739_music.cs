using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium_2.Migrations
{
    public partial class music : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    IdMusician = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Nickname = table.Column<string>(maxLength: 20, nullable: true),
                    MusicianIdMusician = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.IdMusician);
                    table.ForeignKey(
                        name: "FK_Musicians_Musicians_MusicianIdMusician",
                        column: x => x.MusicianIdMusician,
                        principalTable: "Musicians",
                        principalColumn: "IdMusician",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musicians_MusicianIdMusician",
                table: "Musicians",
                column: "MusicianIdMusician");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicians");
        }
    }
}
