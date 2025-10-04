using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class upd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4855));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 42, 48, 631, DateTimeKind.Local).AddTicks(4892));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9218));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9222));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2025, 10, 4, 15, 41, 8, 30, DateTimeKind.Local).AddTicks(9234));
        }
    }
}
