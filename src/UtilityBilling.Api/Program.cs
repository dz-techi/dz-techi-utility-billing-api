using System.Text.Json;
using System.Text.Json.Serialization;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using UtilityBilling.Api;
using UtilityBilling.Application;
using UtilityBilling.Infrastructure;
using UtilityBilling.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApi(builder.Configuration)
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddOpenTelemetry()
    .ConfigureResource(res => res.AddService("UtilityBilling.Api"))
    .WithMetrics(m =>
    {
        m.AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();

        m.AddOtlpExporter(options =>
        {
            options.Endpoint = new Uri("http://localhost:18889");
        });
    })
    .WithTracing(t =>
    {
        t.AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();
        
        t.AddOtlpExporter(options =>
        {
            options.Endpoint = new Uri("http://localhost:18889");
        });
    });

builder.Logging.AddOpenTelemetry(options =>
{
    options.AddConsoleExporter()
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("UtilityBilling.Api"));
    
    options.AddOtlpExporter(opt =>
    {
        opt.Endpoint = new Uri("http://localhost:18889");
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SeedData();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder =>
{
    builder
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
});

// TODO: This ugly part will be removed when this issue is fixed: https://github.com/dotnet/aspnetcore/issues/51888
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
