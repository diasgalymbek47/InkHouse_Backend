using InkHouse.Exceptions;
using InkHouse.Models;

namespace InkHouse.Middlewares;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (HttpException e)
        {
            logger.LogError("Ошибка запроса: {error} | Статус кода: {statusCode}", e.Message, e.StatusCode);
            await ExceptionHandlerAsync(context, e);
        }
        catch (Exception e)
        {
            logger.LogError("Ошибка сервера: {error}", e.Message);
            await ExceptionHandlerAsync(context, e);
        }
    }

    private static async Task ExceptionHandlerAsync(HttpContext context, HttpException e)
    {
        var error = new HttpBadResponse
        {
            Message = "Ошибка при выполнении запроса",
            Details = e.Message
        };

        context.Response.StatusCode = (int)e.StatusCode;
        await context.Response.WriteAsJsonAsync(error);
    }

    private static async Task ExceptionHandlerAsync(HttpContext context, Exception e)
    {
        var error = new HttpBadResponse
        {
            Message = "Ошибка на сервере, попробуйте через 15мин",
            Details = e.Message
        };
        
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(error);
    }
}