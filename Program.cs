using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;
using AprovadosConcursosApi.Application.Services;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Application.Interfaces.Services;
using AprovadosConcursosApi.Domain.Interfaces.IUnitOfWork;
using AprovadosConcursosApi.Infrastructure.UnitOfWork;
using AprovadosConcursosApi.Domain.Interfaces.Repositories;
using AprovadosConcursosApi.Infrastructure.Repositories;
using AprovadosConcursosApi.Application.Interfaces.Repositorie;

var builder = WebApplication.CreateBuilder(args);

// =========================
// CONTROLLERS
// =========================
builder.Services.AddControllers();

// =========================
// JWT AUTH
// =========================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
        ),

        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine("JWT ERROR: " + context.Exception.Message);
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

// =========================
// DB CONTEXT
// =========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// =========================
// DEPENDENCY INJECTION
// =========================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEditalService, EditalService>();
builder.Services.AddScoped<IOrgaoService, OrgaoService>();
builder.Services.AddScoped<IBancaService, BancaService>();
builder.Services.AddScoped<ICargoService, CargoService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEditalRepository, EditalRepository>();
builder.Services.AddScoped<IOrgaoRepository, OrgaoRepository>();
builder.Services.AddScoped<IBancaRepository, BancaRepository>();
builder.Services.AddScoped<ICargoRepository, CargoRepository>();

// =========================
// CORS (FIX REAL PARA PRE-FLIGHT)
// =========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetPreflightMaxAge(TimeSpan.FromMinutes(10));
    });
});

// =========================
// SWAGGER
// =========================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Digite: Bearer {seu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
    });
});

// =========================
// BUILD APP
// =========================
var app = builder.Build();

// 🔥 DEBUG (opcional)
app.Use(async (context, next) =>
{
    Console.WriteLine($"REQ: {context.Request.Method} {context.Request.Path}");
    await next();
});

app.UseRouting();

app.UseCors("AllowFrontend"); // 🔥 OBRIGATÓRIO AQUI

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();