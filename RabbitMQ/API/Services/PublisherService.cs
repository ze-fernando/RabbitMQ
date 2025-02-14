using MassTransit;
using RabbitMQ.API.Models;
using RabbitMQ.API.Repository;

namespace RabbitMQ.API.Services;
public class PublisherService(IBus bus, AppDbContext repository)
{
   private readonly IBus _bus = bus;
   private readonly AppDbContext _repository = repository;
   public async Task<Transaction> CreateTransaction(Transaction transaction)
   {
      var _transaction = new Transaction{
         Sender = transaction.Sender,
         To = transaction.To,
         Confirmed = false,
         Value = transaction.Value,
         Date = DateTime.Now
      };

      _repository.Transactions.Add(_transaction);
      await _repository.SaveChangesAsync();
      
      await _bus.Publish(_transaction);

      return _transaction;
   }
}