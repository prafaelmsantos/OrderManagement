namespace OrderManagement.API.Swagger.SchemaFilters
{
    public sealed class SwaggerRequiredSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties is null)
            {
                return;
            }

            foreach (var schemProperty in schema.Properties)
            {
                if (schemProperty.Value.Nullable)
                {
                    continue;
                }

                if (!schema.Required.Contains(schemProperty.Key))
                {
                    schema.Required.Add(schemProperty.Key);
                }
            }
        }
    }
}
