using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate0000000002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "product_order",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.RenameColumn(
                name: "thirty_six_months",
                table: "product_order",
                newName: "nine_months");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nine_months",
                table: "product_order",
                newName: "thirty_six_months");

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "address", "city", "contact", "created_date", "full_name", "postal_code", "tax_identification_number" },
                values: new object[,]
                {
                    { 1L, "Rua das Flores 10", "Lisboa", "912345678", new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9670), "João Silva", "1000-001", "123456789" },
                    { 2L, "Avenida Central 25", "Porto", "913456789", new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9675), "Maria Santos", "4000-123", "987654321" },
                    { 3L, "Rua da Liberdade 8", "Coimbra", "914567890", new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9678), "António Santos", "3000-045", "192837465" },
                    { 4L, "Travessa do Sol 12", "Leiria", "915678901", new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9680), "José Santos", "2400-002", "564738291" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "created_date", "description", "reference", "unit_price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9833), "Camisola de algodão", "P-1001", 19.989999999999998 },
                    { 2L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9835), "Calças de ganga", "P-1002", 39.990000000000002 },
                    { 3L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9837), "Casaco de inverno", "P-1003", 59.990000000000002 },
                    { 4L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9839), "T-shirt básica", "P-1004", 9.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created_date", "customer_id", "observations", "payment_method" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9865), 1L, "Este documento não serve de fatura.", "A pronto pagamento." },
                    { 2L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9866), 2L, "Este documento não serve de fatura.", "A pronto pagamento." },
                    { 3L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9868), 3L, "Este documento não serve de fatura.", "A pronto pagamento." },
                    { 4L, new DateTime(2025, 11, 17, 13, 56, 1, 240, DateTimeKind.Utc).AddTicks(9869), 4L, "Este documento não serve de fatura.", "A pronto pagamento." }
                });

            migrationBuilder.InsertData(
                table: "product_order",
                columns: new[] { "id", "color", "eight_years", "eighteen_months", "four_years", "one_month", "one_year", "order_id", "product_id", "six_months", "six_years", "ten_years", "thirty_six_months", "three_months", "three_years", "total_price", "total_quantity", "twelve_months", "twelve_years", "twenty_four_months", "two_years", "unit_price", "zero_months" },
                values: new object[,]
                {
                    { 1L, "Verde", 0, 0, 0, 2, 0, 1L, 1L, 0, 0, 0, 0, 1, 0, 59.969999999999999, 3, 0, 0, 0, 0, 19.989999999999998, 0 },
                    { 2L, "Azul", 0, 0, 0, 0, 0, 1L, 2L, 1, 0, 0, 0, 0, 0, 119.97, 3, 2, 0, 0, 0, 39.990000000000002, 0 },
                    { 3L, "Vermelho", 0, 0, 0, 0, 0, 2L, 3L, 0, 0, 0, 0, 0, 0, 0.0, 0, 0, 0, 0, 0, 59.990000000000002, 0 },
                    { 4L, "Preto", 0, 0, 0, 0, 0, 2L, 4L, 0, 0, 0, 0, 0, 0, 0.0, 0, 0, 0, 0, 0, 9.9900000000000002, 0 },
                    { 5L, "Branco", 0, 0, 0, 0, 0, 3L, 3L, 0, 0, 0, 0, 0, 0, 0.0, 0, 0, 0, 0, 0, 59.990000000000002, 0 },
                    { 6L, "Cinza", 0, 0, 0, 0, 0, 4L, 4L, 0, 0, 0, 0, 0, 0, 0.0, 0, 0, 0, 0, 0, 9.9900000000000002, 0 }
                });
        }
    }
}
