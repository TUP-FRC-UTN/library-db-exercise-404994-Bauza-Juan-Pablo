using Library.Context;
using Library.Repositories;
using Library.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar los repository a Service
builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<ILibroRepository, LibroRepository>();

//Agregar context a Service
builder.Services.AddDbContext<LibreriaContext>((context) =>
{
    //Se debe colocar la conexion en appseting.json y aca colocar el key de la cadena
    context.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
