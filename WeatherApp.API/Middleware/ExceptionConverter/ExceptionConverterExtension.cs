using Microsoft.AspNetCore.Builder;

namespace WeatherApp.API.Middleware
{
    public static class ExceptionConverterExtension
    {
        public static IApplicationBuilder UseExceptionConverter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionConverterMiddleware>();
        }
    }
}
