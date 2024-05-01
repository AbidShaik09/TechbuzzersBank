using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    /// <inheritdoc />
    public partial class DataUValidationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Roi = table.Column<int>(type: "int", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    Due = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loans_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DebitId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userDetails_account_Account",
                        column: x => x.Account,
                        principalTable: "account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoansId = table.Column<string>(type: "nvarchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payables_loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "loans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_loans_AccountId",
                table: "loans",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payables_LoansId",
                table: "Payables",
                column: "LoansId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_AccountId",
                table: "transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_Account",
                table: "userDetails",
                column: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payables");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "loans");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
