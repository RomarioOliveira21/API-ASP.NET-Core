using APIConsole.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddWindowsService();
builder.Services.AddScoped<Database>();

builder.WebHost.ConfigureKestrel(configureOptions =>
{
    configureOptions.ListenAnyIP(5000);
});

var app = builder.Build();
app.MapControllers();
app.Run();