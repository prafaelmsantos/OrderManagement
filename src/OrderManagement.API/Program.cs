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
            string host = "/ordermanagement";
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }

            app.UsePathBase(host);
            app.UseCors(CustomPolicy);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.AddErrorHandlerMiddleware();
            app.UseMiddleware<TrialMiddleware>();
            //app.UseSwaggerDocs();

            // app.UseHttpsRedirection();
            app.UseRouting();
            app.MapControllers();
            app.MapFallbackToFile("index.html");
            app.MapGet($"{host}/", async context => await context.Response.WriteAsync("There is http communication endpoints."));
            app.Run();
        }
    }
}
