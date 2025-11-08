namespace OrderManagement.API.Swagger
{
    public sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        #region Private variables
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly SwaggerSettings _swaggerSettings;
        #endregion

        #region Constructors
        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider,
            IOptions<SwaggerSettings> options)
        {
            _provider = provider;
            _swaggerSettings = options.Value;
        }
        #endregion

        #region Public methods
        public void Configure(SwaggerGenOptions options)
        {
            // add swagger document for every API version discovered
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            options.SupportNonNullableReferenceTypes();
            options.SchemaFilter<SwaggerRequiredSchemaFilter>();
            options.SchemaFilter<SwaggerEnumSchemaFilter>();

            // Load documentation;
            var xmlPath = GetXMLDocsFilePath();
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        }
        #endregion

        #region Private methods
        private OpenApiInfo CreateVersionInfo(ApiVersionDescription versionDescription)
        {
            OpenApiInfo info = new()
            {
                Title = _swaggerSettings.Title,
                Description = _swaggerSettings.Description,
                Version = versionDescription.GroupName
            };

            if (versionDescription.IsDeprecated)
            {
                info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
            }

            return info;
        }

        private static string? GetXMLDocsFilePath()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly is null)
            {
                return null;
            }

            var xmlFilename = $"{entryAssembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

            return xmlPath;
        }
        #endregion
    }
}
