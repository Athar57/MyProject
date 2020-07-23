using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminLTE.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CitiesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CitiesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Created_Date",
                table: "Customers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CitiesId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_CityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Customers",
                newName: "Created_Date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CitiesId",
                table: "Customers",
                column: "CitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_CitiesId",
                table: "Customers",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "CitiesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
