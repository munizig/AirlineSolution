using Manager.Application.Logger;
using Manager.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Manager.API.Middleware
{
    public class JsonUnhandledExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public IApplicationLogger ApplicationLogger { get; }

        public JsonUnhandledExceptionMiddleware(RequestDelegate next, IApplicationLogger applicationLogger)
        {
            _next = next;
            ApplicationLogger = applicationLogger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                ApplicationLogger.Error(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            var message = "Unexpected error ocurred. Please contact the system's adminstrator.";

            await response.WriteAsync(JsonConvert.SerializeObject(
                new DefaultContractResponse(code, message)
                ));
        }
    }
}
