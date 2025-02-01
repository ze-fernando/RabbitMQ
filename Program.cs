using Microsoft.EntityFrameworkCore;
using RabbitMQ.API.Infra;
using RabbitMQ.API.Repository;
using RabbitMQ.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddRabbitMQ();

builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<ConsumerService>();

var conf = new RabbitMqConfig();
builder.Configuration.GetSection("RabbitMqConfig").Bind(conf);

builder.Services.AddDbContext<TransactionRepository>( options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Connection")
    )
);
var app = builder.Build();

app.MapControllers();
app.Run();