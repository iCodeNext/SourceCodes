using ResultPattern.Application;
using ResultPattern.Application.Common.Interfaces;
using ResultPattern.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.RegisterApplicationServices();

var app = builder.Build();
app.MapControllers();
app.Run();
