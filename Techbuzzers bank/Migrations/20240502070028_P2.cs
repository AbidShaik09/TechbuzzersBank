using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class P2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDetails_account_Account",
                table: "userDetails");

            migrationBuilder.DropIndex(
                name: "IX_userDetails_Account",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "Account",
                table: "userDetails");

            migrationBuilder.AddColumn<string>(
                name: "accountId",
                table: "userDetails",
                type: "nvarchar(12)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_accountId",
                table: "userDetails",
                column: "accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_userDetails_account_accountId",
                table: "userDetails",
                column: "accountId",
                principalTable: "account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userDetails_account_accountId",
                table: "userDetails");

            migrationBuilder.DropIndex(
                name: "IX_userDetails_accountId",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "accountId",
                table: "userDetails");

            migrationBuilder.AddColumn<string>(
                name: "Account",
                table: "userDetails",
                type: "nvarchar(12)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_Account",
                table: "userDetails",
                column: "Account");

            migrationBuilder.AddForeignKey(
                name: "FK_userDetails_account_Account",
                table: "userDetails",
                column: "Account",
                principalTable: "account",
                principalColumn: "Id");
        }
    }
}
