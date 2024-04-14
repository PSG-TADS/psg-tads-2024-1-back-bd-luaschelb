using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LocadoraContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
