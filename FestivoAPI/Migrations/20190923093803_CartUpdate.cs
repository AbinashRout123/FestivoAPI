using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivoAPI.Migrations
{
    public partial class CartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "carts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductPrice",
                table: "carts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "carts");
        }
    }
}
