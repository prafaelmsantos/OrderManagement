namespace OrderManagement.Application.ServicesRegistry
{
    public static class ServiceCollectionExtension
    {
        #region Public methods
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAppSettingsOptions();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductOrderService, ProductOrderService>();

            return services;
        }
        #endregion

        #region Private methods
        private static void AddAppSettingsOptions(this IServiceCollection services)
        {
            services
                .ConfigureOptions<AppSettingsSetup>()
                .AddOptionsWithValidateOnStart<AppSettings, AppSettingsValidator>();
        }
        #endregion
    }
}
