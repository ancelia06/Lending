using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lending_CapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_CustomerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_LoanOfficerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanSchemes_LoanCompanies_CompanyId",
                table: "LoanSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanBranches_LoanBranchBranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanCompanies_LoanCompanyId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanCompanies_LoanCompanyId1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "LoanCompanies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchLocation",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "LoanCompanyId",
                table: "User",
                newName: "LoanBankId");

            migrationBuilder.RenameColumn(
                name: "LoanBranchBranchId",
                table: "User",
                newName: "LoanBankBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LoanCompanyId",
                table: "User",
                newName: "IX_User_LoanBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LoanBranchBranchId",
                table: "User",
                newName: "IX_User_LoanBankBankId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Repayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoanBankBankId",
                table: "LoanBranches",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusUpdatedDate",
                table: "LoanApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_BranchId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "LoanBank",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanBank", x => x.BankId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanBranches_LoanBankBankId",
                table: "LoanBranches",
                column: "LoanBankBankId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BranchId",
                table: "User",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Customer_BranchId",
                table: "User",
                column: "Customer_BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_User_CustomerId",
                table: "LoanApplications",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_User_LoanOfficerId",
                table: "LoanApplications",
                column: "LoanOfficerId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBranches_LoanBank_LoanBankBankId",
                table: "LoanBranches",
                column: "LoanBankBankId",
                principalTable: "LoanBank",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanSchemes_LoanBank_CompanyId",
                table: "LoanSchemes",
                column: "CompanyId",
                principalTable: "LoanBank",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanBank_LoanBankBankId",
                table: "User",
                column: "LoanBankBankId",
                principalTable: "LoanBank",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanBank_LoanBankId",
                table: "User",
                column: "LoanBankId",
                principalTable: "LoanBank",
                principalColumn: "BankId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanBranches_BranchId",
                table: "User",
                column: "BranchId",
                principalTable: "LoanBranches",
                principalColumn: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_LoanBranches_Customer_BranchId",
                table: "User",
                column: "Customer_BranchId",
                principalTable: "LoanBranches",
                principalColumn: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_User_CustomerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_User_LoanOfficerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBranches_LoanBank_LoanBankBankId",
                table: "LoanBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanSchemes_LoanBank_CompanyId",
                table: "LoanSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanBank_LoanBankBankId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanBank_LoanBankId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanBranches_BranchId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_LoanBranches_Customer_BranchId",
                table: "User");

            migrationBuilder.DropTable(
                name: "LoanBank");

            migrationBuilder.DropIndex(
                name: "IX_LoanBranches_LoanBankBankId",
                table: "LoanBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BranchId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Customer_BranchId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoanBankBankId",
                table: "LoanBranches");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Customer_BranchId",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "LoanBankId",
                table: "Users",
                newName: "LoanCompanyId");

            migrationBuilder.RenameColumn(
                name: "LoanBankBankId",
                table: "Users",
                newName: "LoanBranchBranchId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoanBankId",
                table: "Users",
                newName: "IX_Users_LoanCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoanBankBankId",
                table: "Users",
                newName: "IX_Users_LoanBranchBranchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Repayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusUpdatedDate",
                table: "LoanApplications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "BranchLocation",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "LoanCompanies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCompanies", x => x.CompanyId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_CustomerId",
                table: "LoanApplications",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_LoanOfficerId",
                table: "LoanApplications",
                column: "LoanOfficerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanSchemes_LoanCompanies_CompanyId",
                table: "LoanSchemes",
                column: "CompanyId",
                principalTable: "LoanCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanBranches_LoanBranchBranchId",
                table: "Users",
                column: "LoanBranchBranchId",
                principalTable: "LoanBranches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanCompanies_LoanCompanyId",
                table: "Users",
                column: "LoanCompanyId",
                principalTable: "LoanCompanies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanCompanies_LoanCompanyId1",
                table: "Users",
                column: "LoanCompanyId",
                principalTable: "LoanCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
