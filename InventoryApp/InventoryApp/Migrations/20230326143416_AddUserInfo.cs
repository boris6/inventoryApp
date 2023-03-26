using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Bins_BinID",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Products_ProductID",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocation_Users_CreatedByUserId",
                table: "Allocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Bins_Users_CreatedByUserId",
                table: "Bins");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Bins_CreatedByUserId",
                table: "Bins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocation",
                table: "Allocation");

            migrationBuilder.DropIndex(
                name: "IX_Allocation_CreatedByUserId",
                table: "Allocation");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Allocation");

            migrationBuilder.RenameTable(
                name: "Allocation",
                newName: "Allocations");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_ProductID",
                table: "Allocations",
                newName: "IX_Allocations_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Allocation_BinID",
                table: "Allocations",
                newName: "IX_Allocations_BinID");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Bins",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Allocations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations",
                column: "AllocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_Bins_BinID",
                table: "Allocations",
                column: "BinID",
                principalTable: "Bins",
                principalColumn: "BinID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_Products_ProductID",
                table: "Allocations",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_Bins_BinID",
                table: "Allocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_Products_ProductID",
                table: "Allocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allocations",
                table: "Allocations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Bins");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Allocations");

            migrationBuilder.RenameTable(
                name: "Allocations",
                newName: "Allocation");

            migrationBuilder.RenameIndex(
                name: "IX_Allocations_ProductID",
                table: "Allocation",
                newName: "IX_Allocation_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Allocations_BinID",
                table: "Allocation",
                newName: "IX_Allocation_BinID");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Bins",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Allocation",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allocation",
                table: "Allocation",
                column: "AllocationID");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bins_CreatedByUserId",
                table: "Bins",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocation_CreatedByUserId",
                table: "Allocation",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Bins_BinID",
                table: "Allocation",
                column: "BinID",
                principalTable: "Bins",
                principalColumn: "BinID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Products_ProductID",
                table: "Allocation",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocation_Users_CreatedByUserId",
                table: "Allocation",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bins_Users_CreatedByUserId",
                table: "Bins",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
