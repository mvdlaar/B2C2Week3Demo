using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2C2Week3Demo.Migrations
{
    public partial class Week41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MandId",
                table: "Fruits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Materiaal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Kleur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manden", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fruits_MandId",
                table: "Fruits",
                column: "MandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fruits_Manden_MandId",
                table: "Fruits",
                column: "MandId",
                principalTable: "Manden",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fruits_Manden_MandId",
                table: "Fruits");

            migrationBuilder.DropTable(
                name: "Manden");

            migrationBuilder.DropIndex(
                name: "IX_Fruits_MandId",
                table: "Fruits");

            migrationBuilder.DropColumn(
                name: "MandId",
                table: "Fruits");
        }
    }
}
