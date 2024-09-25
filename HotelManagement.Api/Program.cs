using System.Text.Json.Serialization;
using HotelManagement.Api.Middleware;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Persistence;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();


// подключение к постгре
builder.Services.AddDbContext<HotelManagementDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<EnumSchemaFilter>(); // Добавление фильтра для схемы
});

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();