using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPInc.SPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTransactionQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 8, 16, 8, 54, 38, 588, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2024, 9, 16, 8, 54, 38, 588, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpireDate",
                value: new DateTime(2024, 10, 16, 8, 54, 38, 588, DateTimeKind.Local).AddTicks(9790));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 8, 16, 7, 16, 30, 676, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2024, 9, 16, 7, 16, 30, 676, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpireDate",
                value: new DateTime(2024, 10, 16, 7, 16, 30, 676, DateTimeKind.Local).AddTicks(7335));
        }
    }
}
