using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Configuration SQL
var ConnectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DbpokeMasterContext>(
    options => options.UseSqlServer(connectionString: ConnectionString)
);

builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// A�adimos CORS para que pueda ser usada desde cualquier puerto
var RuleCORS = "RuleCORS";
builder.Services.AddCors(
    options => options.AddPolicy(name: RuleCORS, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(RuleCORS);

app.UseAuthorization();

app.MapControllers();

app.Run();
