using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    accountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    roi = table.Column<int>(type: "int", nullable: false),
                    tenure = table.Column<int>(type: "int", nullable: false),
                    due = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Payables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loansid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payables_loans_Loansid",
                        column: x => x.Loansid,
                        principalTable: "loans",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payables_Loansid",
                table: "Payables",
                column: "Loansid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payables");

            migrationBuilder.DropTable(
                name: "loans");
        }
    }
}
