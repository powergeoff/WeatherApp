using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using WeatherApp.API.Middleware;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Db;
using WeatherApp.Db.Repositories;
using WeatherApp.Services;
using WeatherApp.Services.Builders;
using WeatherApp.Services.Configuration;
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


    builder.Services.AddDbContext<WeatherAppDbContext>(options =>
        options.UseMongoDB(config.ConnectionString ?? "", config.DbName ?? "")
    );

    var authConfig = config.AuthConfig;
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authConfig.Issuer,
                ValidAudience = authConfig.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.Key)),
            };
        });
    //Jwt configuration ends here

    // Add services to the container.

    //builder.Services.AddControllers();
    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );
    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
    });

    builder.Services.AddScoped<IServiceManager, ServiceManager>();

    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

    //custom services or Application Services not Framework services
    builder.Services.AddScoped<ILayerCustomizations, LayerCustomizations>();
    //register factories
    builder.Services.AddScoped<IHatLayerFactory, HatLayerFactory>();
    builder.Services.AddScoped<ITopLayersFactory, TopLayersFactory>();
    builder.Services.AddScoped<IHandsLayerFactory, HandsLayerFactory>();
    builder.Services.AddScoped<IBottomLayerFactory, BottomLayerFactory>();
    //register services
    builder.Services.AddScoped<IOpenWeatherMapService, OpenWeatherMapService>();
    //register builder/ directors
    builder.Services.AddScoped<IRinkClothesBuilder, RinkClothesBuilder>(); //unique pass through interface that implements common interface
    builder.Services.AddScoped<IClothesBuilder, ClothesBuilder>(); //how to register multiple classes that implement same interface
    builder.Services.AddScoped<IClothesDirector, ClothesDirector>();
    //db services

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

    app.UseAuthentication();
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