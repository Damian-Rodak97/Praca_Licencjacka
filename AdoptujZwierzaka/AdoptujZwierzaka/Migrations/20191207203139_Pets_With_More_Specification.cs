using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptujZwierzaka.Migrations
{
    public partial class Pets_With_More_Specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Activity",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Pets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activity",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");
        }
    }
}
