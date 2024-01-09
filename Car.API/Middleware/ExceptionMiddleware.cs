using Newtonsoft.Json;
using System.Net;

namespace Car.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Internal Server Error";
            switch (exception)
            {
                case ArgumentNullException _:
                    statusCode = HttpStatusCode.BadRequest;
                    message = "One or more parameters are null.";
                    break;
                default:
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
