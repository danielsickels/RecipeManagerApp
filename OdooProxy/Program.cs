using Microsoft.EntityFrameworkCore;
using RecipesApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the RecipesContext with PostgreSQL
builder.Services.AddDbContext<RecipesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RecipesDatabase")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/error"); // Ensure you implement this endpoint
}

app.MapControllers();

app.Run();
