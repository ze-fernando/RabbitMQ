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
builder.Services.AddScoped<TransactionService>();

var conf = new RabbitMqConfig();
builder.Configuration.GetSection("RabbitMqConfig").Bind(conf);

builder.Services.AddDbContext<AppDbContext>( options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbConnection")
    )
);

builder.Services.AddSwaggerGen(sg =>
{
    sg.SwaggerDoc("v1", new OpenApiInfo { Title = "RabbitMQ Example", Version = "v1" });
});

var app = builder.Build();

app.MapControllers();
app.Run();
