using Microsoft.EntityFrameworkCore;
using TonRoadVoteApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext с PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Контроллеры и Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Применение миграций базы данных перед запуском сервиса
//PrepDb.PrepPopulation(app);

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

// Используем переменную PORT (Railway)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();
