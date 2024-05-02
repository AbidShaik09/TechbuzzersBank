using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class P6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "accounts",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accounts",
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
    }
}
