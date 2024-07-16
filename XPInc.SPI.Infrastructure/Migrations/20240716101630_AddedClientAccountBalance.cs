using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPInc.SPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedClientAccountBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalBalance",
                table: "Clients",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBalance",
                table: "Clients");

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 8, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2024, 9, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2819));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpireDate",
                value: new DateTime(2024, 10, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2821));
        }
    }
}
