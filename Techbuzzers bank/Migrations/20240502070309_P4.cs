using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class P4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserDetailsId",
                table: "account",
                type: "nvarchar(12)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_UserDetailsId",
                table: "account",
                column: "UserDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_userDetails_UserDetailsId",
                table: "account",
                column: "UserDetailsId",
                principalTable: "userDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_userDetails_UserDetailsId",
                table: "account");

            migrationBuilder.DropIndex(
                name: "IX_account_UserDetailsId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "UserDetailsId",
                table: "account");

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
    }
}
