using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_POS_System.Migrations
{
    /// <inheritdoc />
    public partial class changedSale1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Taken",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Taken",
                table: "Sales");
        }
    }
}
