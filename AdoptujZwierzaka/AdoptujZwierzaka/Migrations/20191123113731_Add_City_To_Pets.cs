using Microsoft.EntityFrameworkCore.Migrations;

namespace AdoptujZwierzaka.Migrations
{
    public partial class Add_City_To_Pets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pets",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Pets");
        }
    }
}
