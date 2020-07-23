using CodeCheater.Infrastructure.Messages;
using CodeCheater.Infrastructure.ValidationException;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CodeCheater.Infrastructure.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, IWebHostEnvironment env)
        {
            var error = new FailedMessageModel
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            error.Description = env.IsDevelopment() ? ex.StackTrace : ex.Message;

            switch(ex)
            {
                case ApplicationValidationException e:
                    error.Message = e.Message;
                    error.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    break;
                default:
                    error.Message = "Error encountered while processing";
                    break;
            }

            var result = JsonConvert.SerializeObject(error);
            context.Response.StatusCode = error.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);


        }
    }
}
