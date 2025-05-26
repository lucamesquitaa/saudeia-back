using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SaudeIA.Data;
using SaudeIA.Facades;
using System.Text;
using System.Text.Json;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddScoped<UserFacade>();
builder.Services.AddScoped<HotelFacade>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

string connectionString = builder.Configuration.GetValue<string>("connectionstring", "");
var jwtToken = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("jwttoken", ""));

builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(connectionString)
);

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
              jwtToken
          )
      };
      options.Events = new JwtBearerEvents
      {
        OnAuthenticationFailed = context =>
        {
          if (context.Exception is SecurityTokenExpiredException)
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
          var result = JsonSerializer.Serialize(new
          {
            status = 401,
            error = "Token is expired or invalid"
          });
          return context.Response.WriteAsync(result);
        }
      };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotelaria API", Version = "v1" });

  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Por favor, insira o token JWT com o prefixo 'Bearer '",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
  });

  // Adiciona o requisito de seguran�a
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


  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotelaria API v1");
  });


app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
