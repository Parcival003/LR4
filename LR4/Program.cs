var builder = WebApplication.CreateBuilder(args);

// Додай сервіс конфігурації
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Додай сервіс контролерів
builder.Services.AddControllers();

var app = builder.Build();

// Додай маршрутизацію
app.MapControllers();

app.Run();
