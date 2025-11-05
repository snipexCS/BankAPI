using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class nice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "IsAdmin",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "IsAdmin",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "IsAdmin",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4020));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4055));
        }
    }
}
