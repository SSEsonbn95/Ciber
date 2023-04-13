using Microsoft.AspNetCore.Http;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlerMiddleware> _logger;
    public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (SqlException ex)
        {
            _logger.LogError(ex, "Database error"); 
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Database error");
        }
        catch (FileNotFoundException ex)
        {
            _logger.LogError(ex, "File not found"); 
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("File not found");
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError(ex, "Access denied"); 
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access denied");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Internal server error"); 
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Internal server error");
        }
    }
}
