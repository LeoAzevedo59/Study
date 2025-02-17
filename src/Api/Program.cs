using Api.Filters;
using Application;
using Infra;
using Infra.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description =
                "Token JWT será enviado via `header`, Configure seu token conforme o exemplo: `Bearer eyJhbG...`",
            In = ParameterLocation.Header,
            Scheme = "Bearer",
            Type = SecuritySchemeType.ApiKey
        });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddMvc(options =>
    options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfra();
builder.Services.AddApplication();

byte[] signinKey =
    Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SIGNIN_KEY") ??
                           string.Empty);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = new TimeSpan(0),
            IssuerSigningKey = new SymmetricSecurityKey(signinKey)
        };
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using AsyncServiceScope scope = app.Services.CreateAsyncScope();
    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}
