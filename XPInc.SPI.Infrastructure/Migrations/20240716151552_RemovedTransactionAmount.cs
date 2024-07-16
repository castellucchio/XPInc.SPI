using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPInc.SPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTransactionAmount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "TotalBalance",
                value: 5000000m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "TotalBalance",
                value: 1000000m);

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 8, 16, 12, 15, 51, 697, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2024, 9, 16, 12, 15, 51, 697, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpireDate",
                value: new DateTime(2024, 10, 16, 12, 15, 51, 697, DateTimeKind.Local).AddTicks(6677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                column: "TotalBalance",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2,
                column: "TotalBalance",
                value: 0m);

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
    }
}
