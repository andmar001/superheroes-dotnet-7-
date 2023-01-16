global using SuperHeroAPI_dotnet7.Models; //Agregar la referencia a los modelos de manera global
using SuperHeroAPI_dotnet7.Data;
using SuperHeroAPI_dotnet7.Services.SuperHeroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//service superheroes
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
//contexto de la base de datos
builder.Services.AddDbContext<DataContext>();

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
