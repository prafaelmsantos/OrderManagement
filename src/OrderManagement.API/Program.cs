namespace OrderManagement.API
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Program
    {
        const string CustomPolicy = "CustomPolicy";
        const string TokenExpiredHeader = "Token-Expired";
        const int MajorVersion = 1;

        public static async Task Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                ConfigureHost(builder);
                ConfigureServices(builder);

                var app = builder.Build();
                ConfigureApp(app);

                Settings.License = LicenseType.Community;

                // For documentation and implementation details, please visit:
                // https://www.questpdf.com/getting-started.html

                await app.RunAsync();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureHost(WebApplicationBuilder builder)
        {
            builder.WebHost.KestrelConfig();

            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices();


            builder.Services.AddAPIControllerServices(MajorVersion);
            builder.Services.AddSwaggerServices();

            builder.Services.AddCors(o => o.AddPolicy(CustomPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithExposedHeaders(TokenExpiredHeader);
            }));
        }

        private static void ConfigureApp(WebApplication app)
        {
            var host = GetHost(app);

            app.UsePathBase(host);
            app.UseCors(CustomPolicy);

            app.AddErrorHandlerMiddleware();
            app.UseMiddleware<TrialMiddleware>();
            app.UseSwaggerDocs(host);

            app.UseRouting();
            app.MapControllers();
            app.MapGet($"{host}/", async context => await context.Response.WriteAsync("There is http communication endpoints."));
        }

        private static string GetHost(IApplicationBuilder app)
        {
            var appSettings = app.ApplicationServices
                .GetRequiredService<IOptions<AppSettings>>().Value;

            var host = "/" + appSettings.VirtualHost.BasePath;

            return host;
        }
    }
}
