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

            services.AddDbContext<AppDbContext>(options => options
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=OrderManagement.db"));

            return services;
        }
    }
}
