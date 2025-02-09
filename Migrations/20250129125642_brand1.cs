using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_POS_System.Migrations
{
    /// <inheritdoc />
    public partial class brand1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DefaultDiscount",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultDiscount",
                table: "Products");
        }
    }
}
