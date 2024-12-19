using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piramida.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class addSaleProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Sales");

            migrationBuilder.CreateTable(
                name: "Sale_Product_Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale_Product_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Product_Properties_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_Product_Properties_SaleId",
                table: "Sale_Product_Properties",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale_Product_Properties");

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
