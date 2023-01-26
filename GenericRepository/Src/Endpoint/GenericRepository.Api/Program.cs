using GenericRepository.ApplicationService.Services;
using GenericRepository.Contract.Interfaces.ApplicationServices;
using GenericRepository.Contract.Interfaces.Repositories;
using GenericRepository.Domain.Entities;
using GenericRepository.Persistence.Contexts;
using GenericRepository.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GenericRepositoryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GenericRepositoryConStr")));

builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
//builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAddProductService, AddProductService>();

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
