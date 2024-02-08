using System.Text.Json.Serialization;
using WeatherApp.API.Middleware;
using WeatherApp.Services;
using WeatherApp.Services.Builders;
using WeatherApp.Services.Factories;
using WeatherApp.Services.Models;
using WeatherApp.Services.Models.Layers;
using WeatherApp.Services.OpenWeatherMap;

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    Console.WriteLine("App Start");
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                            policy =>
                            {
                                policy.WithOrigins("http://localhost:3000",
                                                    "https://localhost:3000")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                            });
        });

    var config = new ConfigService(builder.Configuration);
    builder.Services.AddSingleton<IConfigService>(config);

    // Add services to the container.

    //builder.Services.AddControllers();
    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
    });

    //custom services or Application Services not Framework services
    builder.Services.AddScoped<ILayerCustomizations, LayerCustomizations>();
    builder.Services.AddScoped<IHatLayerFactory, HatLayerFactory>();
    builder.Services.AddScoped<IOpenWeatherMapService, OpenWeatherMapService>();
    builder.Services.AddScoped<ISimpleClothesService, SimpleClothesService>();
    builder.Services.AddScoped<IClothesBuilder, RinkClothesBuilder>(); //how to register multiple classes that implement same interface
    builder.Services.AddScoped<IClothesBuilder, ClothesBuilder>(); //how to register multiple classes that implement same interface
    builder.Services.AddScoped<IClothesDirector, ClothesDirector>(); //so how does this guy know which one to get?

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

    app.UseCors(MyAllowSpecificOrigins);

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