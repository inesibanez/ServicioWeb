using Microsoft.EntityFrameworkCore;
using geogebra.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<Context>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
//builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("TodoList"));


//"name=ConnectionStrings:DefaultConnection"
//@"Server=(localdb)\mssqllocaldb;Database=Test"
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
