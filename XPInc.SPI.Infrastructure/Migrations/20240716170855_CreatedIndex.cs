using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XPInc.SPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpireDate",
                value: new DateTime(2024, 8, 16, 14, 8, 55, 378, DateTimeKind.Local).AddTicks(423));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpireDate",
                value: new DateTime(2024, 9, 16, 14, 8, 55, 378, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "FinantialProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpireDate",
                value: new DateTime(2024, 10, 16, 14, 8, 55, 378, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId_TransactionDate_Type",
                table: "Transactions",
                columns: new[] { "ClientId", "TransactionDate", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_FinantialProducts_Id",
                table: "FinantialProducts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_ClientId_TransactionDate_Type",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_FinantialProducts_Id",
                table: "FinantialProducts");

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");
        }
    }
}
