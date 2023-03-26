using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class AllocationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations");

            migrationBuilder.DropIndex(
                name: "IX_Allocations_ProductID",
                table: "Allocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations",
                columns: new[] { "ProductID", "BinID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations",
                column: "AllocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_ProductID",
                table: "Allocations",
                column: "ProductID");
        }
    }
}
