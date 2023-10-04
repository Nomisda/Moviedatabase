using System.Text.Json.Serialization;
using MovieDatabase.Data;
using MovieDatabase.Interfaces;
using MovieDatabase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlite<MovieContext>("Data Source= Movies.db");
builder.Services.AddScoped<IMovie, MovieService>();
builder.Services.AddScoped<ISchauspieler, SchauspielerService>();
builder.Services.AddScoped<IRegie, RegieService>();




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
