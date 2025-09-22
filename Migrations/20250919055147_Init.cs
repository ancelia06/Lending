using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lending_CapstoneProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_LoanBranches_LoanBankBankId",
                table: "LoanBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanBank",
                table: "LoanBank");

            migrationBuilder.DropColumn(
                name: "LoanBankBankId",
                table: "LoanBranches");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "LoanBank",
                newName: "LoanBanks");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "LoanSchemes",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanSchemes_CompanyId",
                table: "LoanSchemes",
                newName: "IX_LoanSchemes_BankId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoanBankId",
                table: "Users",
                newName: "IX_Users_LoanBankId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LoanBankBankId",
                table: "Users",
                newName: "IX_Users_LoanBankBankId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Customer_BranchId",
                table: "Users",
                newName: "IX_Users_Customer_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_User_BranchId",
                table: "Users",
                newName: "IX_Users_BranchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Repayments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "LoanSchemes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "LoanBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AssignedCity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanBanks",
                table: "LoanBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanBranches_BankId",
                table: "LoanBranches",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_CustomerId",
                table: "LoanApplications",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Users_LoanOfficerId",
                table: "LoanApplications",
                column: "LoanOfficerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanBranches_LoanBanks_BankId",
                table: "LoanBranches",
                column: "BankId",
                principalTable: "LoanBanks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanSchemes_LoanBanks_BankId",
                table: "LoanSchemes",
                column: "BankId",
                principalTable: "LoanBanks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanBanks_LoanBankBankId",
                table: "Users",
                column: "LoanBankBankId",
                principalTable: "LoanBanks",
                principalColumn: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanBanks_LoanBankId",
                table: "Users",
                column: "LoanBankId",
                principalTable: "LoanBanks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanBranches_BranchId",
                table: "Users",
                column: "BranchId",
                principalTable: "LoanBranches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LoanBranches_Customer_BranchId",
                table: "Users",
                column: "Customer_BranchId",
                principalTable: "LoanBranches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_CustomerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Users_LoanOfficerId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanBranches_LoanBanks_BankId",
                table: "LoanBranches");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanSchemes_LoanBanks_BankId",
                table: "LoanSchemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanBanks_LoanBankBankId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanBanks_LoanBankId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanBranches_BranchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_LoanBranches_Customer_BranchId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_LoanBranches_BankId",
                table: "LoanBranches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanBanks",
                table: "LoanBanks");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "LoanBranches");

            migrationBuilder.DropColumn(
                name: "AssignedCity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "LoanBanks",
                newName: "LoanBank");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "LoanSchemes",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanSchemes_BankId",
                table: "LoanSchemes",
                newName: "IX_LoanSchemes_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LoanBankId",
                table: "User",
                newName: "IX_User_LoanBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LoanBankBankId",
                table: "User",
                newName: "IX_User_LoanBankBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Customer_BranchId",
                table: "User",
                newName: "IX_User_Customer_BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BranchId",
                table: "User",
                newName: "IX_User_BranchId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Repayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "LoanSchemes",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "LoanBankBankId",
                table: "LoanBranches",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanBank",
                table: "LoanBank",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanBranches_LoanBankBankId",
                table: "LoanBranches",
                column: "LoanBankBankId");

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
    }
}
