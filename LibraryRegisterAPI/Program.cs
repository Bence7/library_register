using AutoMapper;
using LibraryEntityFramework;
using LibraryRegisterAPI;
using LibraryRegisterAPI.Models.Entities;
using LibraryRegisterAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
builder.Services.AddSingleton(mapper);
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
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
