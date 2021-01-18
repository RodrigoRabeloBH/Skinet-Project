using Microsoft.EntityFrameworkCore.Migrations;

namespace Skinet.Data.Migrations
{
    public partial class AddedComplementColumnToAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "ShippingAddresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complement",
                table: "ShippingAddresses");
        }
    }
}
