using ApiRestVisualContact.Migrations;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//solo para modo desarrollo
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") 
                   .AllowAnyMethod() 
                   .AllowAnyHeader();
        });
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VisualContactDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDbContext<VisualContactDBContext>(options =>
//{
//    options.UseMySql(builder.Configuration.GetConnectionString("Mysql"), new MySqlServerVersion("8.0.41"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

//app.MapGet("/api/ApiVisual", (VisualContactDBContext context) =>
//{
//    return context.agentesdb.ToList();
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//solo en modo desarrollo
app.UseCors("AllowSpecificOrigin");

app.Run();
