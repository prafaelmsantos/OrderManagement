using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate0000000000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    full_name = table.Column<string>(type: "TEXT", nullable: false),
                    tax_identification_number = table.Column<string>(type: "TEXT", nullable: false),
                    contact = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    postal_code = table.Column<string>(type: "TEXT", nullable: false),
                    city = table.Column<string>(type: "TEXT", nullable: false),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    reference = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    unit_price = table.Column<double>(type: "REAL", nullable: false),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    observations = table.Column<string>(type: "TEXT", nullable: true),
                    payment_method = table.Column<string>(type: "TEXT", nullable: true),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    customer_id = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_order",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    product_id = table.Column<long>(type: "INTEGER", nullable: false),
                    order_id = table.Column<long>(type: "INTEGER", nullable: false),
                    color = table.Column<string>(type: "TEXT", nullable: true),
                    unit_price = table.Column<double>(type: "REAL", nullable: false),
                    zero_months = table.Column<int>(type: "INTEGER", nullable: false),
                    one_month = table.Column<int>(type: "INTEGER", nullable: false),
                    three_months = table.Column<int>(type: "INTEGER", nullable: false),
                    six_months = table.Column<int>(type: "INTEGER", nullable: false),
                    twelve_months = table.Column<int>(type: "INTEGER", nullable: false),
                    eighteen_months = table.Column<int>(type: "INTEGER", nullable: false),
                    twenty_four_months = table.Column<int>(type: "INTEGER", nullable: false),
                    thirty_six_months = table.Column<int>(type: "INTEGER", nullable: false),
                    one_year = table.Column<int>(type: "INTEGER", nullable: false),
                    two_years = table.Column<int>(type: "INTEGER", nullable: false),
                    three_years = table.Column<int>(type: "INTEGER", nullable: false),
                    four_years = table.Column<int>(type: "INTEGER", nullable: false),
                    six_years = table.Column<int>(type: "INTEGER", nullable: false),
                    eight_years = table.Column<int>(type: "INTEGER", nullable: false),
                    ten_years = table.Column<int>(type: "INTEGER", nullable: false),
                    twelve_years = table.Column<int>(type: "INTEGER", nullable: false),
                    total_quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    total_price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_order_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_order_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "address", "city", "contact", "created_date", "full_name", "postal_code", "tax_identification_number" },
                values: new object[,]
                {
                    { 1L, "Rua das Flores 10", "Lisboa", "912345678", new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5829), "João Silva", "1000-001", "123456789" },
                    { 2L, "Avenida Central 25", "Porto", "913456789", new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5838), "Maria Santos", "4000-123", "987654321" },
                    { 3L, "Rua da Liberdade 8", "Coimbra", "914567890", new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5838), "António Santos", "3000-045", "192837465" },
                    { 4L, "Travessa do Sol 12", "Leiria", "915678901", new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(5839), "José Santos", "2400-002", "564738291" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "created_date", "description", "reference", "unit_price" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6090), "Camisola de algodão", "P-1001", 19.989999999999998 },
                    { 2L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6094), "Calças de ganga", "P-1002", 39.990000000000002 },
                    { 3L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6094), "Casaco de inverno", "P-1003", 59.990000000000002 },
                    { 4L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6095), "T-shirt básica", "P-1004", 9.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "id", "created_date", "customer_id", "observations", "payment_method", "status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6122), 1L, "Este documento não serve de fatura.", "A pronto pagamento.", 0 },
                    { 2L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6124), 2L, "Este documento não serve de fatura.", "A pronto pagamento.", 4 },
                    { 3L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6125), 3L, "Este documento não serve de fatura.", "A pronto pagamento.", 1 },
                    { 4L, new DateTime(2025, 11, 10, 13, 57, 1, 980, DateTimeKind.Utc).AddTicks(6126), 4L, "Este documento não serve de fatura.", "A pronto pagamento.", 3 }
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

            migrationBuilder.CreateIndex(
                name: "IX_customers_id",
                table: "customers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_id",
                table: "orders",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_order_id",
                table: "product_order",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_order_order_id",
                table: "product_order",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_order_product_id",
                table: "product_order",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_id",
                table: "products",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_order");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
