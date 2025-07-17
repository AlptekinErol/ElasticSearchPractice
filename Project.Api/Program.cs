using Project.Application.Interfaces;
using Project.Application.Services;
using Project.Infrastructure;
using Project.Infrastructure.Repositories;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using FluentValidation.AspNetCore;
using Project.Contracts.Dto;

var builder = WebApplication.CreateBuilder(args);

// Serilog Konfigürasyonu
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();

// Elastic Client Baðlantýsý
builder.Services.AddSingleton(ElasticClientFactory.CreateClient(builder.Configuration));

// Dependency Injection
builder.Services.AddScoped<IProductRepository, ElasticProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<CreateProductValidatorDto>();
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthCheck (ElasticSearch baðlantý kontrolü için dummy eklenmiþ durumda)
builder.Services.AddHealthChecks()
    .AddCheck("ElasticSearch", () => HealthCheckResult.Healthy("ElasticSearch is OK"));

// Build
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
