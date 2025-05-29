using CalculatorApi.Interfaces;
using CalculatorApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Add controllers
builder.Services.AddControllers();

// 2) Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Calculator API",
        Version = "v1",
        Description = "A simple calculator service"
    });
});

// 3) Register your calculator service
builder.Services.AddTransient(typeof(ICalculatorService<>), typeof(CalculatorService<>));

var app = builder.Build();

// 4) Enable Swagger middleware in all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Calculator API v1");
});

app.MapControllers();
app.Run();
