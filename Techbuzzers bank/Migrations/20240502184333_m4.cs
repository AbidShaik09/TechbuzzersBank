using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "userDetails");

            migrationBuilder.AddColumn<long>(
                name: "AdhaarNumber",
                table: "userDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "userDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PANNumber",
                table: "userDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdhaarNumber",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "userDetails");

            migrationBuilder.DropColumn(
                name: "PANNumber",
                table: "userDetails");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "userDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
