using LibraryEntityFramework;
using LibraryRegisterAPI.Models;
using LibraryRegisterAPI;
using LibraryRegisterAPI.Models.Entities;
using LibraryRegisterAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<LibraryDbContext>(builder.Configuration.GetConnectionString("LocalDB"));
builder.Services.AddScoped<IEntityRepository<Book>, BookRepository>();
builder.Services.AddScoped<IEntityRepository<Member>, MemberRepository>();
builder.Services.AddScoped<IEntityRepository<Rental>, RentalRepository>();

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
