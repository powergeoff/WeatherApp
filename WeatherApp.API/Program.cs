using WeatherApp.API.Middleware;
using WeatherApp.Services;
using WeatherApp.Services.Models;
using WeatherApp.Services.OpenWeatherMap;

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    Console.WriteLine("App Start");
    var builder = WebApplication.CreateBuilder(args);

    var config = new ConfigService(builder.Configuration);
    builder.Services.AddSingleton<IConfigService>(config);

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
    });

    //custom services
    builder.Services.AddScoped<IOpenWeatherMapService, OpenWeatherMapService>();

    builder.Services.AddHttpClient();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    //configure pipeline
    app.UseResponseCompression();
    app.UseExceptionConverter();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    //app.UseAppVersion(); not implemented - probably not necessary

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.Message, "Stopped program because of exception");
    throw;
}
finally
{
    //NLog.LogManager.Shutdown();
    Console.WriteLine("Shutdown");
}