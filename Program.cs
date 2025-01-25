using API.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

builder.Services.Configure<Configuration>(
    builder.Configuration.GetSection("RabbitMQ")
);

app.Run();