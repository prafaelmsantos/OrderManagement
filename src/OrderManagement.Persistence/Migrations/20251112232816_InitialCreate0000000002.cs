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
            migrationBuilder.DropColumn(
                name: "status",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6637));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6638));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6528));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 12, 23, 28, 15, 570, DateTimeKind.Utc).AddTicks(6532));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_date", "status" },
                values: new object[] { new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6122), 0 });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_date", "status" },
                values: new object[] { new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6124), 4 });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 3L,
                columns: new[] { "created_date", "status" },
                values: new object[] { new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6125), 1 });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "id",
                keyValue: 4L,
                columns: new[] { "created_date", "status" },
                values: new object[] { new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6126), 3 });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L,
                column: "created_date",
                value: new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6095));
        }
    }
}
