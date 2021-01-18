using Microsoft.EntityFrameworkCore.Migrations;

namespace Skinet.Data.Identity.Migrations
{
    public partial class AddedComplementColumnToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Address",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Address");
        }
    }
}
