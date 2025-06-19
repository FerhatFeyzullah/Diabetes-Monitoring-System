using System;
using System.Text;
using DiabetesMonitoringSystem.Domain.Entities;
using DiabetesMonitoringSystem.Persistence.Configurations;
using DiabetesMonitoringSystem.Persistence.DbContext;
using DiabetesMonitoringSystem.Persistence.ServiceExtension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddDbContext<DiabetesDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
});
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DiabetesDbContext>();



var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<JwtTokenOptions>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.RequireHttpsMetadata = false;
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            // E�er Authorization header yoksa ? Cookie'den token al
            if (string.IsNullOrEmpty(context.Token) && context.Request.Cookies.ContainsKey("MyAuthCookie"))
            {
                context.Token = context.Request.Cookies["MyAuthCookie"];
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
        NameClaimType = "name",

    };
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Taray�c�dan JavaScript ile eri�ilemesin
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.SameSite = SameSiteMode.Lax; // veya Strict / None
    options.Cookie.Name = "JWT"; // �ste�e ba�l�
    options.LoginPath = "/girisyap"; // Giri� yap�lmad���nda y�nlendirilecek yer
    options.AccessDeniedPath = "/girisyap"; // Yetki yoksa y�nlendirilecek yer
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie �mr�
    options.SlidingExpiration = true; // S�re dolmadan aktifse uzat
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
