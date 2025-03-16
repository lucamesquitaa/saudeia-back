using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SaudeIA.Data;
using SaudeIA.Facades;
using SaudeIA.Facades.Interfaces;
using SaudeIA.Models;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<UserFacade>();
builder.Services.AddScoped<MetasFacade>();
builder.Services.AddScoped<BodyFacade>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

string connectionString = builder.Configuration.GetConnectionString("connectionstring");

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(
        connectionString
    ));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue("jwttoken", "")))
      };
      options.Events = new JwtBearerEvents
      {
        OnAuthenticationFailed = context =>
        {
          if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
          {
            context.Response.Headers.Add("Token-Expired", "true");
          }
          return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
          context.HandleResponse();
          context.Response.StatusCode = 401;
          context.Response.ContentType = "application/json";
          var result = JsonSerializer.Serialize(new { 
            status = 401,
            error = "Token is expired or invalid" });
          return context.Response.WriteAsync(result);
        }
      };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaudeIA API", Version = "v1" });

  // Adiciona a definição de segurança
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Por favor, insira o token JWT com o prefixo 'Bearer '",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
  });

  // Adiciona o requisito de segurança
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
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaudeIA API v1");
    });
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
