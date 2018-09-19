using Microsoft.EntityFrameworkCore.Migrations;

namespace Spd3.Migrations
{
    public partial class TaxAccountTypes_renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxAccounts_TaxAccountType_AccountTypeId",
                table: "TaxAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxAccountType",
                table: "TaxAccountType");

            migrationBuilder.RenameTable(
                name: "TaxAccountType",
                newName: "TaxAccountTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxAccountTypes",
                table: "TaxAccountTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxAccounts_TaxAccountTypes_AccountTypeId",
                table: "TaxAccounts",
                column: "AccountTypeId",
                principalTable: "TaxAccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxAccounts_TaxAccountTypes_AccountTypeId",
                table: "TaxAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxAccountTypes",
                table: "TaxAccountTypes");

            migrationBuilder.RenameTable(
                name: "TaxAccountTypes",
                newName: "TaxAccountType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxAccountType",
                table: "TaxAccountType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxAccounts_TaxAccountType_AccountTypeId",
                table: "TaxAccounts",
                column: "AccountTypeId",
                principalTable: "TaxAccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
