using Microsoft.EntityFrameworkCore;
using MyPocketPal.Data.Data;
using MyPocketPal.Data.Repositories.Interfaces;
using MyPocketPal.Data.Repositories;
using MyPocketPal.Core.Interfaces;
using MyPocketPal.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Db Context
builder.Services.AddDbContext<MyPocketPalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyPocketPalDb")));

// Add services
builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Add repositories
builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
