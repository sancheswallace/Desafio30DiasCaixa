using Azure.Monitor.OpenTelemetry.Exporter;
using MinhaApi.Data;
using MinhaApi.Services;
using MinhaApi.Telemetry;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Instrumentation.Http;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Observability
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder => tracerProviderBuilder
        .AddAspNetCoreInstrumentation(options =>
        {
            options.RecordException = true;
        })
        .AddHttpClientInstrumentation()
        .AddSource(TelemetrySources.ActivitySourceName)
        .AddConsoleExporter()
        .AddAzureMonitorTraceExporter(options =>
        {
            var connectionString = builder.Configuration["ApplicationInsights:ConnectionString"]
                ?? Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                options.ConnectionString = connectionString;
            }
        }))
    .WithMetrics(metricProviderBuilder => metricProviderBuilder
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddConsoleExporter()
        .AddAzureMonitorMetricExporter(options =>
        {
            var connectionString = builder.Configuration["ApplicationInsights:ConnectionString"]
                ?? Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                options.ConnectionString = connectionString;
            }
        }));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro dos repositórios e serviços
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();

builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<IClienteService, ClienteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
