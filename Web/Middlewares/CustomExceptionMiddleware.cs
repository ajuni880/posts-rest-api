using PostsAPI.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;

namespace PostsAPI.Web.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            if (ex is NotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            } 
            else if (ex is BadRequestException badEx)
            {
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(new { message = badEx.Message, errors = badEx.Errors });
            }

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new { message = ex.Message });
            }

            context.Response.Headers.Add("content-type", "application/json");
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
