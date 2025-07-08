using Microsoft.EntityFrameworkCore;
using TonRoadVoteApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL (подключение из переменной окружения Railway)
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger (доступен всегда)
app.UseSwagger();
app.UseSwaggerUI();

// Разрешаем HTTPS-редирект (не мешает Railway)
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Указываем порт для Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

// ВАЖНО: применяем миграции автоматически
PrepDb.PrepPopulation(app);

app.Run();
