using Microsoft.AspNetCore.Mvc.Versioning;

const string CustomPolicy = "CustomPolicy";
const string TokenExpiredHeader = "Token-Expired";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true; // Retorna no header quais versões estão disponíveis
    options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Usar URL /v1/
});

builder.Services.AddCors(o => o.AddPolicy(CustomPolicy, builder =>
{
    builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .WithExposedHeaders(TokenExpiredHeader);
}));

var app = builder.Build();

app.UseCors(CustomPolicy);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
