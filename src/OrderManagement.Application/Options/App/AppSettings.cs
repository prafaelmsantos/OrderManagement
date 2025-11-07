namespace OrderManagement.Application.Options.App
{
    public sealed class AppSettings
    {
        public required string EnvName { get; init; }

        public required VirtualHost VirtualHost { get; init; }

        public required ConnectionString ConnectionStrings { get; init; }
    }
}
