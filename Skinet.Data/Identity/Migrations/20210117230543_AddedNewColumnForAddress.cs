using Microsoft.EntityFrameworkCore.Migrations;

namespace Skinet.Data.Identity.Migrations
{
    public partial class AddedNewColumnForAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Address");
        }
    }
}
