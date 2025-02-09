using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_POS_System.Migrations
{
    /// <inheritdoc />
    public partial class paymentEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Return",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Taken",
                table: "Sales");

            migrationBuilder.AddColumn<decimal>(
                name: "Return",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Taken",
                table: "Payments",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Return",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Taken",
                table: "Payments");

            migrationBuilder.AddColumn<decimal>(
                name: "Return",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Taken",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
