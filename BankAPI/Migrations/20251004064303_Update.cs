using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4020), "Initial deposit", 1 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4036), "Initial deposit", 2 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4039), "Initial deposit", 3 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4040), "Initial deposit", 4 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4043), "Initial deposit", 5 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4045), "Initial deposit", 6 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4046), "Initial deposit", 7 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4048), "Initial deposit", 8 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4050), "Initial deposit", 9 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4052), "Initial deposit", 10 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4053), "Initial deposit", 11 });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                columns: new[] { "Date", "Description", "UserId" },
                values: new object[] { new DateTime(2025, 10, 4, 14, 43, 3, 657, DateTimeKind.Local).AddTicks(4055), "Initial deposit", 12 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Transactions");

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
    }
}
