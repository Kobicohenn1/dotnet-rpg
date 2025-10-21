
global using Models;
global using dotnet_rpg.Services.CharacterService;
global using dotnet_rpg.Dtos.Character;
global using Microsoft.EntityFrameworkCore;
global using dotnet_rpg.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

// Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      
    app.UseSwaggerUI();    
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
