namespace OrderManagement.API.Swagger.SchemaFilters
{
    public sealed class SwaggerEnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema openApiSchema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var names = Enum.GetNames(context.Type);
                var values = Enum.GetValues(context.Type).Cast<int>().ToArray();

                openApiSchema.Type = "integer";
                openApiSchema.Format = null;
                openApiSchema.Enum = values.Select(v => new OpenApiInteger(v))
                    .Cast<IOpenApiAny>().ToList();

                var enumVarNames = new OpenApiArray();
                foreach (var name in names)
                {
                    enumVarNames.Add(new OpenApiString(name));
                }

                openApiSchema.Extensions.Add("x-enum-varnames", enumVarNames);
            }
        }
    }
}
