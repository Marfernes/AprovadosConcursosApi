using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AprovadosConcursosApi.Infrastructure.Data.ContextBase;
using AprovadosConcursosApi.Application.Services;
using AprovadosConcursosApi.Application.Interfaces;
using AprovadosConcursosApi.Application.Interfaces.Repositorie;
using AprovadosConcursosApi.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using AprovadosConcursosApi.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// JWT
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
        )
    };

    //LOGS ADICIONADOS (debug JWT)
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            Console.WriteLine("🔵 HEADER AUTH RECEBIDO: " + context.Request.Headers["Authorization"]);
            return Task.CompletedTask;
        },

        OnAuthenticationFailed = context =>
        {
            Console.WriteLine(context.Exception.Message);
            return Task.CompletedTask;
        },

        OnTokenValidated = context =>
        {
            var role = context.Principal?.Claims
                .FirstOrDefault(x => x.Type.Contains("role"))?.Value;
            return Task.CompletedTask;
        },

        OnChallenge = context =>
        {
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();

//DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//DEPENDENCY INJECTION (AQUI!)
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenService>();

//ADICIONADO (Repository + Service de Users)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Swagger
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
var app = builder.Build();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//IMPORTANTE: ordem correta
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();