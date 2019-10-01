using Microsoft.EntityFrameworkCore.Migrations;

namespace FestivoAPI.Migrations
{
    public partial class phoneno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PinCode",
                table: "checkouts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "checkouts",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PinCode",
                table: "checkouts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "checkouts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
