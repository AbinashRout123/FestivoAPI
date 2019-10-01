using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivoAPI.Migrations
{
    public partial class procart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CartTotal",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CartTotal",
                table: "carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "carts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "carts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
