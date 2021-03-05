using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Trade.Exceptions;

namespace Trade.Middlewares
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ResponseException resp)
            {
                context.Response.StatusCode = (int)resp.Code;
                await context.Response.WriteAsync(resp.Message);
                await context.Response.CompleteAsync();
            }
        }
    }
}