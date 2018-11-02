using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MakeGrandTotalComputed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "Expenses");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.AddColumn<decimal>(
                name: "GrandTotal",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
