using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate0000000002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "thirty_six_months",
                table: "product_order",
                newName: "nine_months");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1224));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1385));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 20, 20, 49, 1, 643, DateTimeKind.Utc).AddTicks(1386));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nine_months",
                table: "product_order",
                newName: "thirty_six_months");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9678));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9868));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9839));
        }
    }
}
