using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WeatherApp.API.Models;
using WeatherApp.Services;

namespace WeatherApp.API.Middleware
{
    public class ExceptionConverterMiddleware
    {
        private readonly ILogger<ExceptionConverterMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly IConfigService _config;

        public ExceptionConverterMiddleware(RequestDelegate next, ILogger<ExceptionConverterMiddleware> logger, IConfigService config)
        {
            _next = next;
            _logger = logger;
            _config = config;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled exception");
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var jsonString = JsonSerializer.Serialize(new CommonResponse
                    {
                        IsError = true,
                        Message = e.Message,
                        Description = e.ToString()
                    }, _config.JsonSettings);
                    await context.Response.WriteAsync(jsonString, Encoding.UTF8);
                }
            }
        }
    }
}
