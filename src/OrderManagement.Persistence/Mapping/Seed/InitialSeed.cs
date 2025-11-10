namespace OrderManagement.Persistence.Mapping.Seed
{
    public static class InitialSeed
    {
        public static void AddInitialSeed(this ModelBuilder modelBuilder)
        {
            // =====================
            // Customers
            // =====================
            var customer1 = new Customer(1, "João Silva", "123456789", "912345678", "Rua das Flores 10", "1000-001", "Lisboa");
            var customer2 = new Customer(2, "Maria Santos", "987654321", "913456789", "Avenida Central 25", "4000-123", "Porto");
            var customer3 = new Customer(3, "António Santos", "192837465", "914567890", "Rua da Liberdade 8", "3000-045", "Coimbra");
            var customer4 = new Customer(4, "José Santos", "564738291", "915678901", "Travessa do Sol 12", "2400-002", "Leiria");

            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3, customer4);

            // =====================
            // Products
            // =====================
            var product1 = new Product(1, "P-1001", "Camisola de algodão", 19.99);
            var product2 = new Product(2, "P-1002", "Calças de ganga", 39.99);
            var product3 = new Product(3, "P-1003", "Casaco de inverno", 59.99);
            var product4 = new Product(4, "P-1004", "T-shirt básica", 9.99);

            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);

            // =====================
            // Orders
            // =====================
            var order1 = new Order(1, OrderStatus.Open, "Este documento não serve de fatura.", "A pronto pagamento.", customer1.Id);
            var order2 = new Order(2, OrderStatus.Cancelled, "Este documento não serve de fatura.", "A pronto pagamento.", customer2.Id);
            var order3 = new Order(3, OrderStatus.Pending, "Este documento não serve de fatura.", "A pronto pagamento.", customer3.Id);
            var order4 = new Order(4, OrderStatus.Delivered, "Este documento não serve de fatura.", "A pronto pagamento.", customer4.Id);

            modelBuilder.Entity<Order>().HasData(order1, order2, order3, order4);

            // =====================
            // ProductOrders (flat, inicializando alguns tamanhos)
            // =====================
            var po1 = new ProductOrder(
                1,
                product1.Id,
                order1.Id,
                "Verde",
                19.99,
                oneMonth: 2,
                threeMonths: 1,
                sixMonths: 0,
                twelveMonths: 0,
                eighteenMonths: 0,
                twentyFourMonths: 0,
                thirtySixMonths: 0,
                oneYear: 0,
                twoYears: 0,
                threeYears: 0,
                fourYears: 0,
                sixYears: 0,
                eightYears: 0,
                tenYears: 0,
                twelveYears: 0
            );

            var po2 = new ProductOrder(
                2,
                product2.Id,
                order1.Id,
                "Azul",
                39.99,
                oneMonth: 0,
                threeMonths: 0,
                sixMonths: 1,
                twelveMonths: 2,
                eighteenMonths: 0,
                twentyFourMonths: 0,
                thirtySixMonths: 0,
                oneYear: 0,
                twoYears: 0,
                threeYears: 0,
                fourYears: 0,
                sixYears: 0,
                eightYears: 0,
                tenYears: 0,
                twelveYears: 0
            );

            var po3 = new ProductOrder(3, product3.Id, order2.Id, "Vermelho", 59.99);
            var po4 = new ProductOrder(4, product4.Id, order2.Id, "Preto", 9.99);
            var po5 = new ProductOrder(5, product3.Id, order3.Id, "Branco", 59.99);
            var po6 = new ProductOrder(6, product4.Id, order4.Id, "Cinza", 9.99);

            modelBuilder.Entity<ProductOrder>().HasData(po1, po2, po3, po4, po5, po6);
        }
    }
}
