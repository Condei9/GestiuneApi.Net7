using GestiuneSaliNET7.Data;
using GestiuneSaliNET7.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILogin, AuthenticateLogin>();
builder.Services.AddCors();
builder.Services.AddMvc();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
        options => options.WithOrigins("http://localhost").AllowAnyMethod()
    );

app.UseMvc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
