using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountType = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionType = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "Name", "Password", "Phone", "Picture" },
                values: new object[,]
                {
                    { 1, "Random Street", "fangyuan@example.com", "Fang Yuan", "pass123", "0123456789", "" },
                    { 2, "Random Street", "redfog@example.com", "Red Fog", "pass123", "0123456789", "" },
                    { 3, "Random Street", "blackevil@example.com", "Black Evil", "pass123", "0123456789", "" },
                    { 4, "Random Street", "liuchen@example.com", "Liu Chen", "pass123", "0123456789", "" },
                    { 5, "Random Street", "shenwei@example.com", "Shen Wei", "pass123", "0123456789", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "Balance", "UserId" },
                values: new object[,]
                {
                    { 1001, "Savings", 6000m, 1 },
                    { 1002, "Savings", 7000m, 2 },
                    { 1003, "Savings", 8000m, 3 },
                    { 1004, "Savings", 9000m, 4 },
                    { 1005, "Savings", 10000m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccountNumber", "Amount", "Date", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1001, 6000m, new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5530), "Deposit" },
                    { 2, 1002, 7000m, new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5557), "Deposit" },
                    { 3, 1003, 8000m, new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5562), "Deposit" },
                    { 4, 1004, 9000m, new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5566), "Deposit" },
                    { 5, 1005, 10000m, new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5574), "Deposit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
