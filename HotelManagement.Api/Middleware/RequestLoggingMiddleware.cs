using System.Diagnostics;
using Serilog;

namespace HotelManagement.Api.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Проверяем, является ли запрос к Swagger
        if (!context.Request.Path.StartsWithSegments("/swagger"))
        {
            Log.Information("Обрабатываемый запрос: {Method} {Path}", context.Request.Method, context.Request.Path);
        }

        await _next(context);
    
        stopwatch.Stop();

        if (!context.Request.Path.StartsWithSegments("/swagger"))
        {
            Log.Information("Обработанный запрос: {Method} {Path} вернул {StatusCode} за {Elapsed:0.0000} ms",
                context.Request.Method,
                context.Request.Path,
                context.Response.StatusCode,
                stopwatch.Elapsed.TotalMilliseconds);
        }
    }
    
}