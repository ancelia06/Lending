using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lending_CapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class Ym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RemainingBalance",
                table: "LoanApplications",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingBalance",
                table: "LoanApplications");
        }
    }
}
