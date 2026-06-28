using System.Net;
using System.Text.Json;

namespace ProjektniZadatak.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Neuhvaćena pogreška prilikom obrade zahtjeva {Method} {Path}",
                    context.Request.Method, context.Request.Path);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var odgovor = new
                {
                    statusCode = context.Response.StatusCode,
                    message = "Dogodila se pogreška na poslužitelju."
                };

                var json = JsonSerializer.Serialize(odgovor);
                await context.Response.WriteAsync(json);
            }
        }
    }
}