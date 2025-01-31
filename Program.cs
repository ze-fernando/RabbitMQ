using RabbitMQ.API.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRabbitMQ();

var conf = new RabbitMqConfig();
builder.Configuration.GetSection("RabbitMqConfig").Bind(conf);

Console.WriteLine($"RABBITMQ {RabbitMqConfig.Host}");

var app = builder.Build();

app.Run();