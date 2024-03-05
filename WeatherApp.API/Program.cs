using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using WeatherApp.API.Middleware;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Db;
using WeatherApp.Db.Repositories;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;
using WeatherApp.Infrastructure.Builders;
using WeatherApp.Infrastructure.ExternalServices;
using WeatherApp.Infrastructure.ExternalServices.OpenWeatherMap;

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

    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
    });

    builder.Services.AddScoped<IRepositoryServiceManager, RepositoryServiceManager>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

    builder.Services.AddScoped<IExternalServicesManager, ExternalServicesManager>();
    //register builder/ directors
    builder.Services.AddScoped<IClothesDirector, ClothesDirector>();

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