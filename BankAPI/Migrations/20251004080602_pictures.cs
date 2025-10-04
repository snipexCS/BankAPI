using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankAPI.Migrations
{
    /// <inheritdoc />
    public partial class pictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 7,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 8,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 9,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 10,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6822));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 11,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6824));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 12,
                column: "Date",
                value: new DateTime(2025, 10, 4, 16, 6, 2, 910, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Picture",
                value: "user1.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Picture",
                value: "user2.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Picture",
                value: "user3.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Picture",
                value: "user4.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Picture",
                value: "user5.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Picture",
                value: "user6.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "Picture",
                value: "user7.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "Picture",
                value: "user8.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "Picture",
                value: "user9.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "Picture",
                value: "user10.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "Picture",
                value: "user11.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "Picture",
                value: "user12.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                column: "Picture",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                column: "Picture",
                value: "");
        }
    }
}
