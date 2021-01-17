using Microsoft.EntityFrameworkCore.Migrations;

namespace Skinet.Data.Migrations
{
    public partial class AddedNewColumnForAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "ShippingAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "ShippingAddresses");
        }
    }
}
