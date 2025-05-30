using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using WeatherApp.API.Middleware;
using WeatherApp.Core.Domain.ExternalServices;
using WeatherApp.Core.Domain.Repositories;
using WeatherApp.Core.RepositoryServices;
using WeatherApp.Db;
using WeatherApp.Db.Repositories;
using WeatherApp.Infrastructure.ApplicationServices;
using WeatherApp.Infrastructure.ApplicationServices.Configuration;
using WeatherApp.Infrastructure.Builders;
using WeatherApp.Infrastructure.ExternalServices;

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
                                                    "https://localhost:3000",
                                                    "https://purple-river-06091300f.6.azurestaticapps.net")
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
        //below is from CP app unsure if we need it
        .AddAuthentication(o =>
        {
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authConfig.Key));
            options.TokenValidationParameters.ValidIssuer = authConfig.Issuer;
            options.TokenValidationParameters.ValidAudience = authConfig.Audience;
            options.TokenValidationParameters.IssuerSigningKey = key;
            options.TokenValidationParameters.ValidateIssuerSigningKey = true;
            options.TokenValidationParameters.ValidateLifetime = true;
            options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
        });

    //Jwt configuration ends here
    builder.Services.AddAuthorization();

    builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

    builder.Services.AddSwaggerGen(option =>
    {
        option.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
            }
        );
        option.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            }
        );
    });

    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
    });
    builder.Services.AddScoped<IGenerateTokenService, GenerateTokenService>();
    builder.Services.AddScoped<IRepositoryServiceManager, RepositoryServiceManager>();
    builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

    builder.Services.AddScoped<IExternalServicesManager, ExternalServicesManager>();
    //register builder/ directors
    builder.Services.AddScoped<IClothesDirector, ClothesDirector>();

    builder.Services.AddHttpClient();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddMemoryCache();//in-memory cache

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