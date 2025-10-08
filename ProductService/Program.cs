using Microsoft.EntityFrameworkCore;
using ProductService.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Переменная окружения CONNECTION_STRING не задана.");

builder.Services.AddDbContext<ProductServiceDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
