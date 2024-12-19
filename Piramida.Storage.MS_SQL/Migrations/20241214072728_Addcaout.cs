using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Piramida.Storage.MS_SQL.Migrations
{
    /// <inheritdoc />
    public partial class Addcaout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "count",
                table: "Cart_products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count",
                table: "Cart_products");
        }
    }
}
