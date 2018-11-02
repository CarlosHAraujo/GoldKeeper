using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cost_Expenses_ExpenseId",
                table: "Cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cost",
                table: "Cost");

            migrationBuilder.DropIndex(
                name: "IX_Cost_ExpenseId",
                table: "Cost");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Cost");

            migrationBuilder.RenameTable(
                name: "Cost",
                newName: "Costs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Costs",
                table: "Costs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ExtraCost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostId = table.Column<int>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    ExpenseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraCost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraCost_Costs_CostId",
                        column: x => x.CostId,
                        principalTable: "Costs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExtraCost_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCost_CostId",
                table: "ExtraCost",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCost_ExpenseId",
                table: "ExtraCost",
                column: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Costs",
                table: "Costs");

            migrationBuilder.RenameTable(
                name: "Costs",
                newName: "Cost");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Cost",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cost",
                table: "Cost",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cost_ExpenseId",
                table: "Cost",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cost_Expenses_ExpenseId",
                table: "Cost",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
