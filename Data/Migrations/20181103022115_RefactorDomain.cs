using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RefactorDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Expenses_ExpenseId",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_Payments_PaymentId",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Expenses_ExpenseId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ExpenseId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_ExpenseId",
                table: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethod_PaymentId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                newName: "PaymentMethods");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CostId",
                table: "ExtraCost",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MethodId",
                table: "Payment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Payment",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ExpenseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ExpenseId",
                table: "Payment",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_MethodId",
                table: "Payment",
                column: "MethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ExpenseId",
                table: "Item",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProductId",
                table: "Item",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost",
                column: "CostId",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Expenses_ExpenseId",
                table: "Payment",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_PaymentMethods_MethodId",
                table: "Payment",
                column: "MethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Expenses_ExpenseId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_PaymentMethods_MethodId",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ExpenseId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_MethodId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "CostId",
                table: "ExtraCost",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "PaymentMethod",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentMethod",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "PaymentMethod",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ExpenseId",
                table: "Products",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_ExpenseId",
                table: "PaymentMethod",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_PaymentId",
                table: "PaymentMethod",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraCost_Costs_CostId",
                table: "ExtraCost",
                column: "CostId",
                principalTable: "Costs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_Expenses_ExpenseId",
                table: "PaymentMethod",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_Payments_PaymentId",
                table: "PaymentMethod",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Expenses_ExpenseId",
                table: "Products",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
