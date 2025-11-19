namespace OrderManagement.Persistence.ServicesRegistry
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            string dbFolder = Path.Combine(AppContext.BaseDirectory, "SQLite");
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }


            string dbPath = Path.Combine(dbFolder, "OrderManagement.db");

            services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies()
                       .UseSqlite($"Data Source={dbPath}"));

            return services;
        }
    }
}
