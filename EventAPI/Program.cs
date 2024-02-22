using EventBusiness.Services;
using EventData.DataContext;
using EventData.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Text;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

//builder - container, inbuild middlewares
var builder = WebApplication.CreateBuilder(args);//API
try
{
    //Jwt configuration starts here
    var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
    var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = jwtIssuer,
             ValidAudience = jwtIssuer,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
         };
     });
    // Add services to the container.
    //container- Services
    builder.Services.AddControllers();
    //add connection string
    //read connection string from appsetting.json file
    string conStr = builder.Configuration.GetConnectionString("sqlcon");
    builder.Services.AddDbContext<EventDbContext>(options => options.UseSqlServer(conStr));
    builder.Services.AddScoped<EventService, EventService>();
    builder.Services.AddScoped<UserService, UserService>();
    builder.Services.AddScoped<IUserRepo, UserRepo>();
    builder.Services.AddScoped<IEventRepository, EventRepository>();
    builder.Services.AddScoped<ScheduleService, ScheduleService>();
    builder.Services.AddScoped<IScheduleRepo, ScheduleRepo>();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddCors();//CORS policy
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Event API",
            Description = "Event Management System API",
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."

        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[] { }
            }
        });
    });
        builder.Services.AddLogging(log =>
    {
        log.ClearProviders();
        log.AddConsole();
    });
        var app = builder.Build();// instances will be created

        // Configure the HTTP request pipeline.
        //Dev,Testing,production,QA
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();//middleware
            app.UseSwaggerUI();//middleware
        }
        app.UseCors(x => x.AllowAnyMethod()
                          .AllowAnyHeader()
                          .SetIsOriginAllowed(origin => true) // allow any origin
                          .AllowCredentials());
        //app.UseAuthentication();//login
        app.UseAuthentication();

        app.UseAuthorization();//middleware

        app.MapControllers();//middleware

        app.Run();//middleware-> it will connect controller
    
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program");
}
finally
{
    NLog.LogManager.Shutdown();
}

// 1. Container  - builder
// 2. Middleware - App