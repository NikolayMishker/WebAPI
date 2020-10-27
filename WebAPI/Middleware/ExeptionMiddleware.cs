using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Errors;

namespace WebAPI.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExeptionMiddleware> logger;
        private readonly IHostEnvironment env;
        public ExeptionMiddleware(
            RequestDelegate next, 
            ILogger<ExeptionMiddleware> logger, 
            IHostEnvironment env)
        {
            this.logger = logger;
            this.next = next;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "/application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment()
                    ? new ApiExeption((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiExeption((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy =
                    JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
