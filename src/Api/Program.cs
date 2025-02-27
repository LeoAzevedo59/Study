using Api.Extensions;
using Api.Filters;
using Api.Policy;
using Application;
using Infra;
using Infra.Extensions;
using Infra.Migrations;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc(options =>
    options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfra(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddSwagger();

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy =
        new JsonSnakeCaseNamingPolicy();
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

if (!builder.Configuration.IsTestIntegrationEnvironment())
{
    await MigrateDatabase();
}


app.Run();

async Task MigrateDatabase()
{
    await using AsyncServiceScope scope = app.Services.CreateAsyncScope();
    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}

public abstract partial class Program
{
}
