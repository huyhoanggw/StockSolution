using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSolution.SharedLibrary.Middleware
{
    public class ListenToOnlyApiGateway(RequestDelegate _next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var signedHeaders = context.Request.Headers["Api-Gateway-Signature"];
            if (signedHeaders.FirstOrDefault() is null)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("sorry , service is unavailable");
                return;

            }


            else await _next(context);

        }
    }
}
