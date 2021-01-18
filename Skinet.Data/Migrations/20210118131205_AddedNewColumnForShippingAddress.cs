using Microsoft.EntityFrameworkCore.Migrations;

namespace Skinet.Data.Migrations
{
    public partial class AddedNewColumnForShippingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "ShippingAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ShippingAddresses");
        }
    }
}
