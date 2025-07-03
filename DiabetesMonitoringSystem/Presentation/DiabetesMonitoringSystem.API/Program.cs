using System;
using System.Security.Claims;
using System.Text;
using DiabetesMonitoringSystem.Application.ServiceExtension;
using DiabetesMonitoringSystem.Application.Services;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Infrastructure.ServiceExtension;
using DiabetesMonitoringSystem.Persistence.Configurations;
using DiabetesMonitoringSystem.Persistence.DbContext;
using DiabetesMonitoringSystem.Persistence.ServiceExtension;
using DiabetesMonitoringSystem.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddDbContext<DiabetesDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
});

// Identity servisleri (SignInManager ile birlikte)
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    // Cookie tabanlý oturum yönetimini devre dýþý býrak
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<DiabetesDbContext>()
.AddDefaultTokenProviders();


// JWT
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<JwtTokenOptions>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = builder.Environment.IsDevelopment() ? false : true;
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("MyAuthCookie"))
            {
                context.Token = context.Request.Cookies["MyAuthCookie"];
                Console.WriteLine($"Token from MyAuthCookie: {context.Token}");
            }
            else
            {
                Console.WriteLine("MyAuthCookie not found in request.");
            }
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key)),
        ClockSkew = TimeSpan.Zero,
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();



var provider = builder.Services.BuildServiceProvider();
Console.WriteLine(provider.GetService<IUserService>() is null ? "NULL" : "OK");

