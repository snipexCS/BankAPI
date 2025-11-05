using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7607), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7625), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7628), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7629), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7654), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7656), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7658), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7659), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7662), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7664), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7665), 0 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2025, 10, 2, 13, 45, 12, 249, DateTimeKind.Local).AddTicks(7667), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transactions");

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

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4486));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2025, 10, 2, 9, 53, 58, 25, DateTimeKind.Local).AddTicks(4489));
        }
    }
}
