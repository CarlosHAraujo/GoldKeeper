using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MakeCostProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_ExtraCost_CostId",
                table: "ExtraCost");

            migrationBuilder.DropColumn(
                name: "CostId",
                table: "ExtraCost");

            migrationBuilder.AddColumn<string>(
                name: "Cost",
                table: "ExtraCost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ExtraCost");

            migrationBuilder.AddColumn<int>(
                name: "CostId",
                table: "ExtraCost",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCost_CostId",
                table: "ExtraCost",
                column: "CostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost",
                column: "CostId",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
