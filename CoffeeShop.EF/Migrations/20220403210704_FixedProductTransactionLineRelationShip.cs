using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.EF.Migrations
{
    public partial class FixedProductTransactionLineRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionLine_ProductID",
                table: "TransactionLine");

            migrationBuilder.DropColumn(
                name: "TransactionLineID",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLine_ProductID",
                table: "TransactionLine",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TransactionLine_ProductID",
                table: "TransactionLine");

            migrationBuilder.AddColumn<int>(
                name: "TransactionLineID",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLine_ProductID",
                table: "TransactionLine",
                column: "ProductID",
                unique: true);
        }
    }
}
