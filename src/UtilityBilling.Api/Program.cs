using System.Text.Json;
using System.Text.Json.Serialization;
using UtilityBilling.Api;
using UtilityBilling.Application;
using UtilityBilling.Infrastructure;
using Serilog;
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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower));
    });

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(builder.Configuration);

    configuration.Enrich.WithEnvironmentName();
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

app.UseSerilogRequestLogging();

// TODO: This ugly part will be removed when this issue is fixed: https://github.com/dotnet/aspnetcore/issues/51888
app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
