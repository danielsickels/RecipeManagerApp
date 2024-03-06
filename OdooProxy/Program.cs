using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OdooProxy API", Version = "v1" });
});

// Configure Entity Framework Core to use PostgreSQL
builder.Services.AddDbContext<RecipesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RecipesDatabase")));

var app = builder.Build();

// Middleware for redirecting HTTP requests to HTTPS.
// Use environment variable to control HTTPS redirection in containers or specific environments.
var useHttpsRedirection = builder.Configuration.GetValue<bool>("UseHttpsRedirection");
if (useHttpsRedirection)
{
    app.UseHttpsRedirection();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OdooProxy API V1");
    c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root (http://localhost:<port>/)
});

// app.UseExceptionHandler("/error"); // Make sure you have a controller action to handle "/error" route.

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.Run();
