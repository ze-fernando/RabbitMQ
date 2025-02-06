using MassTransit;
using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;
namespace RabbitMQ.API.Services;
public class ConsumerService : IConsumer<Transaction>
{
    private readonly AppDbContext _context;
    private readonly ILogger<Transaction> _logger;
    public ConsumerService(AppDbContext context, ILogger<Transaction> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<Transaction> context)
    {
        var message = context.Message;
        var transaction = _context.Transactions
        .FirstOrDefault(x => x.Id == message.Id);

        if(transaction != null)
        {
            transaction.Confirmed = true;
        }

        _logger.LogInformation($"Transaction processed {transaction}");
    }
}