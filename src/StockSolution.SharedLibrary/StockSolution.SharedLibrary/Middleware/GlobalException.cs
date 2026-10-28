using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockSolution.SharedLibrary.Logs;
namespace StockSolution.SharedLibrary.Middleware
{
    public class GlobalException(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if (!context.Response.HasStarted)
                {
                    string tilte = string.Empty;
                    string message = string.Empty;
                    int statusCode = context.Response.StatusCode;
                    switch (statusCode)
                    {
                        case StatusCodes.Status401Unauthorized:
                            tilte = "Unauthorized";
                            message = "You are not authorized to access this resource.";
                            break;
                        case StatusCodes.Status403Forbidden:
                            tilte = "Forbidden";
                            message = "You are not allowed to access this resource.";
                            break;
                        case StatusCodes.Status429TooManyRequests:
                            tilte = "Too Many Requests";
                            message = "You have exceeded the allowed number of requests. Please try again later.";
                            break;
                    }
                    if (!string.IsNullOrEmpty(message))
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = statusCode;
                        var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails()
                        {
                            Title = tilte,
                            Detail = message
                        };
                        var json = System.Text.Json.JsonSerializer.Serialize(problemDetails);
                        await context.Response.WriteAsync(json);
                    }
                }

            }
            catch (Exception ex)
            {
                LogException.LogExceptions(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (context.Response.HasStarted) return;
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            string title = "Internal Server Error";
            string message = "An unexpected error occurred. Please try again later.";
            int statusCode = StatusCodes.Status500InternalServerError;
            if (ex is TaskCanceledException || ex is TimeoutException)
            {
                title = "Request Timout";
                message = "Request Timeout ... try again";
                statusCode = StatusCodes.Status408RequestTimeout;
            }
            context.Response.StatusCode = statusCode;
            var ProblemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails()
            {
                Title = title,
                Detail = message
            };
            var json = System.Text.Json.JsonSerializer.Serialize(ProblemDetails);
            await context.Response.WriteAsync(json);
        }
    }
}
