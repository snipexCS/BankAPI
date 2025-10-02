using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4474));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4478));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "Name", "Password", "Phone", "Picture" },
                values: new object[,]
                {
                    { 6, "Random Street", "rengoku@example.com", "Rengoku", "pass123", "0123456789", "" },
                    { 7, "Random Street", "wusheng@example.com", "Wu Sheng", "pass123", "0123456789", "" },
                    { 8, "Random Street", "daoist@example.com", "Daoist", "pass123", "0123456789", "" },
                    { 9, "Random Street", "masterchen@example.com", "Master Chen", "pass123", "0123456789", "" },
                    { 10, "Random Street", "zhurong@example.com", "Zhu Rong", "pass123", "0123456789", "" },
                    { 11, "Random Street", "limu@example.com", "Li Mu", "pass123", "0123456789", "" },
                    { 12, "Random Street", "yanshi@example.com", "Yan Shi", "pass123", "0123456789", "" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "AccountType", "Balance", "UserId" },
                values: new object[,]
                {
                    { 1006, "Savings", 11000m, 6 },
                    { 1007, "Savings", 12000m, 7 },
                    { 1008, "Savings", 13000m, 8 },
                    { 1009, "Savings", 14000m, 9 },
                    { 1010, "Savings", 15000m, 10 },
                    { 1011, "Savings", 16000m, 11 },
                    { 1012, "Savings", 17000m, 12 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "AccountNumber", "Amount", "Date", "TransactionType" },
                values: new object[,]
                {
                    { 6, 1006, 11000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4479), "Deposit" },
                    { 7, 1007, 12000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4481), "Deposit" },
                    { 8, 1008, 13000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4482), "Deposit" },
                    { 9, 1009, 14000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4485), "Deposit" },
                    { 10, 1010, 15000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4486), "Deposit" },
                    { 11, 1011, 16000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4488), "Deposit" },
                    { 12, 1012, 17000m, new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4489), "Deposit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountNumber",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5530));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5557));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 9, 27, 16, 17, 28, 271, DateTimeKind.Local).AddTicks(5574));
        }
    }
}
