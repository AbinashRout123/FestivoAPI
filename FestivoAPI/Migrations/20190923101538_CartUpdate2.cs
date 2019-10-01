using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivoAPI.Migrations
{
    public partial class CartUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductTotal",
                table: "carts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTotal",
                table: "carts");
        }
    }
}
